using Microsoft.AspNetCore.Mvc;

namespace MyBlazorApp.Server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PortfolioController : ControllerBase
{
    // GET: api/portfolio/aggregate
    [HttpGet("aggregate")]
    public IActionResult GetPortfolioAggregate()
    {
        // The middleware will handle the actual aggregation
        return Ok(); // Empty response as middleware processes the request
    }
}