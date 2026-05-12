namespace OrderGenerator.API.Routes;

public static class RouteOrder
{
    public static void AddRouteOrder(this RouteGroupBuilder routeGroupBuilder)
    {
        var routeGroup = routeGroupBuilder.MapGroup(nameof(Order));
        
        routeGroup.MapGet("{code:guid}", GetOrder);
        routeGroup.MapGet("all", GetOrders);
        routeGroup.MapPost("new", CreateNewOrder);
    }

    private static IResult GetOrder([FromServices] IOrderService orderService, [FromRoute] Guid code) =>
        orderService.GetOrder(code)
            .ToHttpResponse();
    
    private static IResult GetOrders([FromServices] IOrderService orderService) =>
        orderService.GetOrders()
            .ToHttpResponse();

    private static IResult CreateNewOrder([FromServices] IOrderService orderService, NewOrderRequestDto dto)
    {
        if (dto.IsInvalid(out var error))
            return error!;
        
        return orderService.CreateNewOrder(dto)
            .ToCreatedResponse();
    }
}