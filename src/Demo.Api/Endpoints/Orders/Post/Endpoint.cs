namespace Demo.Api.Endpoints.Orders.Post;

public static class Endpoint
{
    public static IEndpointRouteBuilder MapOrderPostEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/v1/orders", async (
            OrderPostRequest request,
            [FromServices] IValidator<OrderPostRequest> validator,
            [FromServices] OrderMetrics metrics
        ) =>
        {
            ValidationResult validation = await validator.ValidateAsync(request);

            if (!validation.IsValid)
            {
                var errors = validation.Errors.Select(e => new { e.PropertyName, e.ErrorMessage });
                return Results.BadRequest(errors);
            }

            Guid orderId = Guid.NewGuid();

            await Task.Delay(100); //todo: enqueue message

            Activity.Current?.SetTag("order.id", orderId);

            metrics.RecordOrderAccepted();

            return Results.Accepted(string.Empty, new OrderPostResponse(orderId));
        })
        .Produces<OrderPostResponse>(StatusCodes.Status202Accepted)
        .WithTags("Orders");

        return endpoints;
    }
}