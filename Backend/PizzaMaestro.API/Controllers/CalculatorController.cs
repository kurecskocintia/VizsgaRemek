using Microsoft.AspNetCore.Mvc;
using PizzaMaestro.API.DTOs;
using PizzaMaestro.API.Services;
namespace PizzaMaestro.API.Controllers;
[ApiController][Route("api/[controller]")]
public class CalculatorController(DoughCalculatorService service) : ControllerBase {
 [HttpPost] public ActionResult<CalculatorResponse> Calculate(CalculatorRequest request) {
   if(request.Balls<1 || request.BallWeight<=0 || request.Hydration<=0 || request.Salt<0) return BadRequest("Érvénytelen paraméter.");
   return Ok(service.Calculate(request));
 }
}