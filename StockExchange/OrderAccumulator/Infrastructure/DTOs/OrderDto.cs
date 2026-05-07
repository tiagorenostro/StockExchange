namespace OrderAccumulator.Infrastructure.DTOs;

public class OrderDto(Guid orderId)
{
    public Guid OrderId { get; set; } = orderId;
    public char Status { get; set; }
    
    public void SetStatus(char status) => Status = status;
}