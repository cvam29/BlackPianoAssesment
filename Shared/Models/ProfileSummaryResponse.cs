namespace MyBlazorApp.Shared.Models;

public class Datum
{
    public string id { get; set; }
    public string firmId { get; set; }
    public string name { get; set; }
    public string status { get; set; }
    public string clientType { get; set; }
    public List<string> nodeId { get; set; }
    public string currency { get; set; }
    public double currentValue { get; set; }
    public int accounts { get; set; }
    public double uninvestedCash { get; set; }
    public double growth { get; set; }
    public double growthPercent { get; set; }
    public double adjustedGrowth { get; set; }
    public double adjustedGrowthPercent { get; set; }
    public List<string>? nodeName { get; set; }
}

public class Meta
{
    public int count { get; set; }
    public int page { get; set; }
    public int pageSize { get; set; }
}

public class ProfileSummaryResponse
{
    public List<Datum> data { get; set; }
    public Meta meta { get; set; }
}

