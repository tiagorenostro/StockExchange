namespace OrderGenerator.API.Interfaces;

public interface IOrderService
{
    Result<OrderResponseDto> GetOrder(Guid code);
    IEnumerable<OrderResponseDto> GetOrders();
    Result CreateNewOrder(NewOrderRequestDto dto);
    void ProcessOrderReturn(OrderReportDto dto);
}