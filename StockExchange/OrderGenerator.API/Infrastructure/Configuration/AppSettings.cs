namespace OrderGenerator.API.Infrastructure.Configuration;

public sealed record AppSettings(string? CorsPolicy, string? UrlStockExhangeWeb, string? PathFileConfigurationQuickFIX);