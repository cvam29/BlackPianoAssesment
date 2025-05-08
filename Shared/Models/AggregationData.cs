namespace MyBlazorApp.Shared.Models;
public class ByAccountType
{
    public string? AccountType { get; set; }
    public double TotalValue { get; set; }
}

public class AggregationData
{
    public double TotalValue { get; set; }
    public List<ByAccountType> ByAccountType { get; set; } = [];
    public int PortfolioCount { get; set; }
}