namespace OrderAccumulator.Worker.Services;

public class OrderAccumulatorService : IOrderAccumulatorService
{
    public bool ValidateNewOrder(NewOrder newOrder) => 
        TransactionValueExceededExposureValue(newOrder);
    
    private static bool TransactionValueExceededExposureValue(NewOrder newOrder)
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