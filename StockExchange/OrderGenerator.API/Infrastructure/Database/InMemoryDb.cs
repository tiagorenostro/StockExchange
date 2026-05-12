namespace OrderGenerator.API.Infrastructure.Database;

public static class InMemoryDb
{
    public static ConcurrentDictionary<Guid, Share> Share { get; } = new();
    public static ConcurrentDictionary<Guid, Order> Order { get; } = new();
}