using MyBlazorApp.Server.Services.Interfaces;
using MyBlazorApp.Shared.Models;
using System.Text.Json;

namespace MyBlazorApp.Server.Services.Implementations;
public class SecclApiService : ISecclApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    private readonly ILogger<SecclApiService> _logger;

    public SecclApiService(HttpClient httpClient, IConfiguration configuration, ILogger<SecclApiService> logger)
    {
        _httpClient = httpClient;
        _configuration = configuration;
        _logger = logger;

        // Set BaseAddress in constructor to avoid setting it repeatedly
        var baseUrl = _configuration["SecclApi:BaseUrl"];
        _httpClient.BaseAddress = new Uri(baseUrl);
    }

    public async Task<TokenResponse> GetAccessToken()
    {
        try
        {
            var credentials = new
            {
                firmId = _configuration["SecclApi:FirmId"],
                id = _configuration["SecclApi:Id"],
                password = _configuration["SecclApi:Password"]
            };

            var response = await _httpClient.PostAsJsonAsync("authenticate", credentials);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TokenResponse>(responseString);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during authentication");
            throw;
        }
    }

    private async Task<HttpClient> GetAuthenticatedHttpClientAsync()
    {
        try
        {
            var tokenResponse = await GetAccessToken();
            var token = tokenResponse?.Data?.Token;
            if (string.IsNullOrEmpty(token))
            {
                _logger.LogError("Token is null or empty");
                throw new Exception("Token is null or empty");
            }

            // Remove existing api-token header to prevent duplicates
            _httpClient.DefaultRequestHeaders.Remove("api-token");
            _httpClient.DefaultRequestHeaders.Add("api-token", token);

            return _httpClient;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error configuring authenticated HttpClient");
            throw;
        }
    }

    public async Task<List<PortfolioReportData>> GetPortFolioAsync()
    {
        try
        {
            var httpClient = await GetAuthenticatedHttpClientAsync();
            var firmId = _configuration["SecclApi:FirmId"];
            var response = await httpClient.GetAsync($"portfolio/{firmId}?pageSize=100&page=1");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var summary = JsonSerializer.Deserialize<ProfileSummaryResponse>(responseString);

            if (summary?.data == null)
            {
                _logger.LogWarning("No portfolio data found in response");
                return new List<PortfolioReportData>();
            }

            // Get reports for first 3 clients
            var clientIds = summary.data.Take(3).Select(d => d.id).ToList();
            var portfolioReports = new List<PortfolioReportData>();


            foreach (var clientId in clientIds)
            {
                var report = await GetPortFolioReport(clientId);
                if (report != null)
                {
                    portfolioReports.Add(report);
                }
            }

            return portfolioReports;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during portfolio retrieval");
            throw;
        }
    }

    public async Task<PortfolioReportData> GetPortFolioReport(string clientId)
    {
        try
        {
            var httpClient = await GetAuthenticatedHttpClientAsync();
            var firmId = _configuration["SecclApi:FirmId"];
            var response = await httpClient.GetAsync($"portfolio/report/{firmId}/{clientId}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PortfolioReport>(responseString);

            if (result?.Data == null)
            {
                _logger.LogWarning($"No portfolio report data found for client {clientId}");
                return null;
            }

            return result.Data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving portfolio report for client {clientId}");
            throw;
        }
    }
}
