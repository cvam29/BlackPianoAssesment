using System.Text.Json.Serialization;

namespace MyBlazorApp.Shared.Models;

public class Charges
{
    [JsonPropertyName("transactions")]
    public List<Transaction> Transactions { get; set; } = [];

    [JsonPropertyName("total")]
    public double Total { get; set; }
}

public class PortfolioReportData
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("firmId")]
    public string? FirmId { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("payments")]
    public Payments? Payments { get; set; }

    [JsonPropertyName("charges")]
    public Charges? Charges { get; set; }

    [JsonPropertyName("retainedInterest")]
    public RetainedInterest? RetainedInterest { get; set; }

    [JsonPropertyName("income")]
    public Income? Income { get; set; }

    [JsonPropertyName("transfers")]
    public Transfers? Transfers { get; set; }

    [JsonPropertyName("internalTransfers")]
    public InternalTransfers? InternalTransfers { get; set; }

    [JsonPropertyName("performance")]
    public Performance? Performance { get; set; }

    [JsonPropertyName("openingValue")]
    public int OpeningValue { get; set; }

    [JsonPropertyName("closingValue")]
    public double ClosingValue { get; set; }
}

public class Income
{
    [JsonPropertyName("transactions")]
    public List<Transaction>? Transactions { get; set; }

    [JsonPropertyName("total")]
    public double Total { get; set; }
}

public class InternalTransfers
{
    [JsonPropertyName("transactionsIn")]
    public List<TransactionsIn>? TransactionsIn { get; set; }

    [JsonPropertyName("transactionsOut")]
    public List<TransactionsOut>? TransactionsOut { get; set; }

    [JsonPropertyName("totalIn")]
    public double TotalIn { get; set; }

    [JsonPropertyName("totalOut")]
    public double TotalOut { get; set; }
}

public class Payments
{
    [JsonPropertyName("transactionsIn")]
    public List<TransactionsIn>? TransactionsIn { get; set; }

    [JsonPropertyName("transactionsOut")]
    public List<object>? TransactionsOut { get; set; }

    [JsonPropertyName("totalIn")]
    public int TotalIn { get; set; }

    [JsonPropertyName("totalOut")]
    public int TotalOut { get; set; }
}

public class Performance
{
    [JsonPropertyName("transactionsRealised")]
    public List<object>? TransactionsRealised { get; set; }

    [JsonPropertyName("positionsRetained")]
    public List<PositionsRetained>? PositionsRetained { get; set; }

    [JsonPropertyName("totalRealised")]
    public int TotalRealised { get; set; }

    [JsonPropertyName("totalRetained")]
    public double TotalRetained { get; set; }
}

public class PositionsRetained
{
    [JsonPropertyName("isin")]
    public string? Isin { get; set; }

    [JsonPropertyName("assetName")]
    public string? AssetName { get; set; }

    [JsonPropertyName("quantity")]
    public double Quantity { get; set; }

    [JsonPropertyName("bookValue")]
    public double BookValue { get; set; }

    [JsonPropertyName("transferBookValue")]
    public int TransferBookValue { get; set; }

    [JsonPropertyName("nonTransferBookValue")]
    public double NonTransferBookValue { get; set; }

    [JsonPropertyName("currentValue")]
    public double CurrentValue { get; set; }

    [JsonPropertyName("growth")]
    public double Growth { get; set; }

    [JsonPropertyName("adjustedGrowth")]
    public double AdjustedGrowth { get; set; }
}

public class RetainedInterest
{
    [JsonPropertyName("transactions")]
    public List<object>? Transactions { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }
}

public class PortfolioReport
{
    [JsonPropertyName("data")]
    public PortfolioReportData? Data { get; set; }
}

public class Transaction
{
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("transactionCode")]
    public string? TransactionCode { get; set; }

    [JsonPropertyName("narrative")]
    public string? Narrative { get; set; }

    [JsonPropertyName("postDate")]
    public DateTime PostDate { get; set; }

    [JsonPropertyName("valueDate")]
    public DateTime ValueDate { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }
}

public class TransactionsIn
{
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("transactionCode")]
    public string? TransactionCode { get; set; }

    [JsonPropertyName("narrative")]
    public string? Narrative { get; set; }

    [JsonPropertyName("postDate")]
    public DateTime PostDate { get; set; }

    [JsonPropertyName("valueDate")]
    public DateTime ValueDate { get; set; }

    [JsonPropertyName("subscriptionAmount")]
    public double SubscriptionAmount { get; set; } // Changed to double

    [JsonPropertyName("amount")]
    public double Amount { get; set; } // Changed to double
}

public class TransactionsOut
{
    [JsonPropertyName("transactionId")]
    public string? TransactionId { get; set; }

    [JsonPropertyName("transactionCode")]
    public string? TransactionCode { get; set; }

    [JsonPropertyName("narrative")]
    public string? Narrative { get; set; }

    [JsonPropertyName("postDate")]
    public DateTime PostDate { get; set; }

    [JsonPropertyName("valueDate")]
    public DateTime ValueDate { get; set; }

    [JsonPropertyName("subscriptionAmount")]
    public double SubscriptionAmount { get; set; }

    [JsonPropertyName("amount")]
    public double Amount { get; set; }
}

public class Transfers
{
    [JsonPropertyName("transactionsIn")]
    public List<object>? TransactionsIn { get; set; }

    [JsonPropertyName("transactionsOut")]
    public List<object>? TransactionsOut { get; set; }

    [JsonPropertyName("totalIn")]
    public int TotalIn { get; set; }

    [JsonPropertyName("totalOut")]
    public int TotalOut { get; set; }
}

