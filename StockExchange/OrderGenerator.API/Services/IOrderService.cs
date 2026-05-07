namespace OrderGenerator.API.Services;

public interface IOrderService
{
    bool CreateNewOrder(OrderRequestDto orderDto);
}