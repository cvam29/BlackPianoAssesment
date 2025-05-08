using MyBlazorApp.Server.Services.Interfaces;
using System.Text.Json;

namespace MyBlazorApp.Server.Midlleware;

public class PortfolioAggregationMiddleware
{
    private readonly RequestDelegate _next;

    public PortfolioAggregationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ISecclApiService secclApiService)
    {
        if (context.Request.Path == "/api/portfolio/aggregate")
        {
            try
            {
                var portfolios = await secclApiService.GetPortFolioAsync();
                var aggregation = new
                {
                    TotalValue = portfolios.Sum(p => p.ClosingValue),
                    ByAccountType = portfolios
                        .GroupBy(p => p.Name?.Contains("ISA") == true ? "ISA" : "GIA")
                        .Select(g => new
                        {
                            AccountType = g.Key,
                            TotalValue = g.Sum(p => p.ClosingValue)
                        })
                        .ToList(),
                    PortfolioCount = portfolios.Count
                };

                // Set response properties before starting the response
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";

                // Serialize and write the response
                await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(aggregation));
            }
            catch (Exception ex)
            {
                // Always set headers before writing any content
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";

                // Now write the error message
                await context.Response.WriteAsync($"Error aggregating portfolio data: {ex.Message}");
            }
        }
        else
        {
            await _next(context);
        }
    }
}
