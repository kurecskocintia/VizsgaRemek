using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PizzaMaestro.API.Data;
using PizzaMaestro.API.Models;

namespace PizzaMaestro.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    AppDbContext db,
    IConfiguration configuration
) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            return BadRequest("A felhasználónév kötelező.");

        if (string.IsNullOrWhiteSpace(request.Email))
            return BadRequest("Az email cím kötelező.");

        if (string.IsNullOrWhiteSpace(request.Password))
            return BadRequest("A jelszó kötelező.");

        if (request.Password.Length < 6)
            return BadRequest("A jelszónak legalább 6 karakter hosszúnak kell lennie.");

        var email = request.Email.Trim().ToLowerInvariant();
        var userName = request.UserName.Trim();

        if (await db.Users.AnyAsync(x => x.Email == email))
            return Conflict("Ez az email cím már használatban van.");

        if (await db.Users.AnyAsync(x => x.UserName == userName))
            return Conflict("Ez a felhasználónév már használatban van.");

        var user = new User
        {
            UserName = userName,
            Email = email
        };

        var hasher = new PasswordHasher<User>();

        user.PasswordHash = hasher.HashPassword(
            user,
            request.Password
        );

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return Ok(new
        {
            message = "Sikeres regisztráció."
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var email = request.Email.Trim().ToLowerInvariant();

        var user = await db.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
            return Unauthorized("Hibás email cím vagy jelszó.");

        var hasher = new PasswordHasher<User>();

        var result = hasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            request.Password
        );

        if (result == PasswordVerificationResult.Failed)
            return Unauthorized("Hibás email cím vagy jelszó.");

        var token = GenerateToken(user);

        return Ok(new
        {
            token,
            user = new
            {
                id = user.Id,
                userName = user.UserName,
                email = user.Email
            }
        });
    }

    private string GenerateToken(User user)
    {
        var jwt = configuration.GetSection("Jwt");

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwt["Key"]!)
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()
            ),

            new Claim(
                ClaimTypes.Name,
                user.UserName
            ),

            new Claim(
                ClaimTypes.Email,
                user.Email
            )
        };

        var expiresMinutes =
            int.TryParse(jwt["ExpiresMinutes"], out var minutes)
                ? minutes
                : 1440;

        var token = new JwtSecurityToken(
            issuer: jwt["Issuer"],
            audience: jwt["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

public record RegisterRequest(
    string UserName,
    string Email,
    string Password
);

public record LoginRequest(
    string Email,
    string Password
);