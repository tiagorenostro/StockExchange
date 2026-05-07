namespace OrderGenerator.API.Routes;

public static class RoutePing
{
    public static void AddRoutePing(this RouteGroupBuilder routeGroupBuilder) =>
        routeGroupBuilder.MapGroup("ping")
            .MapGet("/", () => TypedResults.Ok("Pong"));
}