using MyBlazorApp.Shared.Models;

namespace MyBlazorApp.Server.Services.Interfaces;

public interface ISecclApiService
{
    Task<TokenResponse> GetAccessToken();
    Task<List<PortfolioReportData>> GetPortFolioAsync();
    Task<PortfolioReportData> GetPortFolioReport(string clientId);
}
