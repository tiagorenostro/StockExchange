namespace OrderGenerator.API.Interfaces;

public interface IShareService
{
    void Save(Share share);
    void ProcessOperation(Order order);
    Result<ShareResponseDto> GetShare(Guid code);
    IEnumerable<ShareResponseDto> GetShares();
    Result<Share> CreateShareIfNotExistAndValidate(NewOrderRequestDto dto);
}