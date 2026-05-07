namespace OrderGenerator.API.Services;

public class OrderService(ITradingGateway tradingGateway) : IOrderService
{
    public bool CreateNewOrder(OrderRequestDto orderDto) =>
        tradingGateway.SendOrder(orderDto);
}