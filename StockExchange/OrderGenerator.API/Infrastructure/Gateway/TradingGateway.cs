namespace OrderGenerator.API.Infrastructure.Gateway;

public interface ITradingGateway
{
    bool SendOrder(OrderRequestDto orderRequestDto);
}

public class TradingGateway(IInitiatorApplication initiatorApplication) : ITradingGateway
{
    public bool SendOrder(OrderRequestDto orderRequestDto) =>
        initiatorApplication.SendOrder(orderRequestDto);

    public static void ReceiveOrder(OrderReportDto orderReportDto)
    {
        Console.WriteLine($"Validating Report {orderReportDto.Status}");
    }
}