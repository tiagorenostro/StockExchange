namespace OrderAccumulator.Infrastructure.Repository;

public interface IShareRepository
{
    Share GetOrAdd(string symbol);
    bool ExistShareExecuted(string symbol);
}