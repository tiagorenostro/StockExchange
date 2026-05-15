namespace OrderAccumulator.Worker.Interfaces;

public interface IOrderAccumulatorService
{
    bool ValidateNewOrder(NewOrder newOrder);
}