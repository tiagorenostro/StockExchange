namespace OrderAccumulator.Worker.Services;

public interface IOrderAccumulatorService
{
    bool ValidateNewOrder(NewOrder newOrder);
}

public class OrderAccumulatorService : IOrderAccumulatorService
{
    public bool ValidateNewOrder(NewOrder newOrder) => 
        ValidateValueExposure(newOrder);
    
    private static bool ValidateValueExposure(NewOrder newOrder)
    {
        decimal newValueExposure;
        
        var currentExposure = GetCurrentExposure(newOrder.Symbol!);

        if (newOrder.IsOrderBuy())
        {
            newValueExposure = currentExposure + newOrder.TotalValue;

            if (newValueExposure > ValueExposure.LimitPerSymbol)
                return false;
        }
        else
            newValueExposure = currentExposure - newOrder.TotalValue;
        
        UpdateValueExposure(newOrder.Symbol!, newValueExposure);

        return true;
    }

    private static decimal GetCurrentExposure(string symbol)
    {
        InMemoryDb.Exposures.TryGetValue(symbol, out var currentExposure);
        
        return currentExposure;
    }
    
    private static void UpdateValueExposure(string symbol, decimal newValueExposure) =>
        InMemoryDb.Exposures[symbol] = newValueExposure;
}