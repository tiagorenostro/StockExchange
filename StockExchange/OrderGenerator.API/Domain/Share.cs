namespace OrderGenerator.API.Domain;

public class Share
{
    private readonly List<Guid> _orderCodes = [];
    
    public Guid Code { get; }
    public string? Symbol { get; private set; }
    public int TotalAmount { get; private set; }
    public decimal AveragePrice { get; private set; }
    public decimal FinancialExposure { get; private set; }
    public char Status { get; private set; }
    public IReadOnlyCollection<Guid> OrderCodes => _orderCodes;

    private Share(string symbol)
    {
        Code = Guid.NewGuid();
        Symbol = symbol;
        
        SetStatus(Constants.Status.New);
    }
    
    private void SetStatus(char status) => Status = status;

    private void CalculateAveragePrice() =>   
        AveragePrice = FinancialExposure / TotalAmount;
    
    private void AddOrder(Order order)
    {
        if (!_orderCodes.Contains(order.Code))
            _orderCodes.Add(order.Code);
    }
    
    private void CalculateFinancialExposure(Order order)
    {
        var modifier = order.Side switch
        {
            Constants.Side.Sell => -1,
            Constants.Side.Buy => 1,
            _ => 0
        };
        
        var operatingValueModifier = order.OperatingValue * modifier;
        FinancialExposure += operatingValueModifier;
    }

    private void AddPurchaseOrder(Order order)
    {
        TotalAmount += order.Amount;
        AddOrder(order);
    }

    private void AddSalesOrder(Order order)
    {
        if (order.Amount > TotalAmount)
            order.SetAmount(TotalAmount);
        
        TotalAmount -= order.Amount;

        if (IsNoPosition())
            AveragePrice = 0;
            
        AddOrder(order);
    }
    
    public bool IsNoPosition() => TotalAmount == 0;

    public void SetActiveAsNoPosition()
    {
        TotalAmount = 0;
        SetStatus(Constants.Status.Long);
    } 
    
    public void ProcessOrder(Order order)
    {
        order.LinkShare(Code);
        
        if (order.IsOrderRejected())
        {
            AddOrder(order);
            return;
        }
        
        CalculateFinancialExposure(order);
        
        if (order.IsOrderSell())
        {
            AddSalesOrder(order);
            return;
        }
        
        SetStatus(Constants.Status.Flat);
        AddPurchaseOrder(order);
        CalculateAveragePrice();
    }

    public static Result<Share> Create(string? symbol) =>
        symbol!.Length is < Constants.Symbol.MinimumSymbolSize or > Constants.Symbol.MaximumSymbolSize ? 
            Result<Share>.Fail(new Error(ErrorType.Validation, MessageError.UnprocessedOrder, 
                [new Field(nameof(Symbol), MessageError.SymbolIsLong)])) : 
            Result<Share>.Ok(new Share(symbol));
}