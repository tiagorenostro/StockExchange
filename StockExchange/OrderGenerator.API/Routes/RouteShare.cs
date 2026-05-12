namespace OrderGenerator.API.Routes;

public static class RouteShare
{
    public static void AddRouteShare(this RouteGroupBuilder routeGroupBuilder)
    {
        var routeGroup = routeGroupBuilder.MapGroup(nameof(Share));
        
        routeGroup.MapGet("all", GetShares);
        routeGroup.MapGet("{code:guid}", GetShare);
    }
    
    private static IResult GetShares([FromServices] IShareService shareService) =>
        shareService.GetShares()
            .ToHttpResponse();

    private static IResult GetShare([FromServices] IShareService shareService, [FromRoute] Guid code) =>
        shareService.GetShare(code)
            .ToHttpResponse();
}