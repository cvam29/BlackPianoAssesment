using System.Text.Json.Serialization;

namespace MyBlazorApp.Shared.Models;

public class Data
{
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }

    [JsonPropertyName("userType")]
    public string? UserType { get; set; }

    [JsonPropertyName("scopes")]
    public List<ScopeInfo>? Scopes { get; set; } = [];

    [JsonPropertyName("services")]
    public List<string>? Services { get; set; } = [];
}

public class TokenResponse
{
    [JsonPropertyName("data")]
    public Data? Data { get; set; }
}

public class ScopeInfo
{
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [JsonPropertyName("ranges")]
    public List<string>? Ranges { get; set; }
}