namespace OrderAccumulator.Services;

public interface IOrderService
{
    Result<OrderDto> NewOrder(NewOrderSingle order);
}