namespace OrderGenerator.API.Routes;

public static class RouteOrder
{
    public static void AddRouteOrder(this RouteGroupBuilder routeGroupBuilder)
    {
        var routeGroup = routeGroupBuilder.MapGroup("order");

        routeGroup.MapPost("new", CreateNewOrder);
    }

    private static IResult CreateNewOrder([FromServices] IOrderService orderService, OrderRequestDto dto)
    {
        var isValid = ValidateRequest(dto, out var results);
        
        if (!isValid)
            return TypedResults.BadRequest(results.Select(x => x.ErrorMessage));
        
        var sent = orderService.CreateNewOrder(dto);
        
        if (!sent)
            return TypedResults.BadRequest("The order could not be sent.");
        
        return TypedResults.Created();
    }

    private static bool ValidateRequest(OrderRequestDto dto, out ICollection<ValidationResult> validationResults)
    {
        validationResults = new List<ValidationResult>();
        return Validator.TryValidateObject(dto, new ValidationContext(dto), validationResults, validateAllProperties: true);
    }
}