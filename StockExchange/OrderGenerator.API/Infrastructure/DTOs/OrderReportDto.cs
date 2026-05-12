namespace OrderGenerator.API.Infrastructure.DTOs;

public sealed record OrderReportDto(Guid CodeOrder,
    string? Symbol,
    decimal Amount,
    decimal Price,
    char Status,
    char Side);