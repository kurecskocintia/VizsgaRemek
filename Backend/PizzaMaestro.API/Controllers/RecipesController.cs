using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaMaestro.API.Data;
using PizzaMaestro.API.DTOs;
using PizzaMaestro.API.Models;
using PizzaMaestro.API.Services;

namespace PizzaMaestro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class RecipesController(
    AppDbContext db,
    DoughCalculatorService calculator
) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized();

        var recipes = await db.Recipes
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(recipes);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized();

        var recipe = await db.Recipes
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId
            );

        if (recipe == null)
            return NotFound();

        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaveRecipeRequest request)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized();

        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest("A recept neve kötelező.");

        if (request.Name.Length > 200)
            return BadRequest(
                "A recept neve legfeljebb 200 karakter lehet."
            );

        var calculatorRequest = new CalculatorRequest(
            request.Balls,
            request.BallWeight,
            request.Hydration,
            request.SaltPercent,
            request.YeastType,
            request.RoomTemp,
            request.RoomHours,
            request.FridgeTemp,
            request.FridgeHours
        );

        var calculated = calculator.Calculate(calculatorRequest);

        var recipe = new Recipe
        {
            UserId = userId.Value,

            Name = request.Name.Trim(),
            Description = request.Description?.Trim() ?? "",

            Balls = request.Balls,
            BallWeight = request.BallWeight,

            YeastType = request.YeastType,
            Hydration = calculated.Hydration,
            SaltPercent = calculated.SaltPercent,

            TotalDoughWeight = calculated.TotalDoughWeight,
            FlourGrams = calculated.FlourGrams,
            WaterGrams = calculated.WaterGrams,
            SaltGrams = calculated.SaltGrams,
            YeastGrams = calculated.YeastGrams,
            YeastLabel = calculated.YeastLabel,

            SourdoughFlourGrams = calculated.SourdoughFlourGrams,
            SourdoughWaterGrams = calculated.SourdoughWaterGrams,

            RoomTemp = calculated.RoomTemp,
            RoomHours = calculated.RoomHours,
            FridgeTemp = calculated.FridgeTemp,
            FridgeHours = calculated.FridgeHours,
            TotalHours = calculated.TotalHours,

            CreatedAt = DateTime.UtcNow
        };

        db.Recipes.Add(recipe);
        await db.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetById),
            new { id = recipe.Id },
            recipe
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var userId = GetUserId();

        if (userId == null)
            return Unauthorized();

        var recipe = await db.Recipes
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.UserId == userId
            );

        if (recipe == null)
            return NotFound();

        db.Recipes.Remove(recipe);
        await db.SaveChangesAsync();

        return NoContent();
    }

    private int? GetUserId()
    {
        var claim = User.FindFirstValue(
            ClaimTypes.NameIdentifier
        );

        if (int.TryParse(claim, out var userId))
            return userId;

        return null;
    }
}