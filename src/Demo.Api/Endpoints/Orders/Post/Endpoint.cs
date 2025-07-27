namespace Demo.Api.Endpoints.Orders.Post;

public static class PostEndpoint
{
    public static IEndpointRouteBuilder MapOrderPostEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/v1/Orders/Post", async (
            OrderPostRequest request,
            [FromServices] IValidator<OrderPostRequest> validator
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

            return Results.Accepted(string.Empty, new OrderPostResponse(orderId));
        })
        .Produces<OrderPostResponse>(StatusCodes.Status202Accepted)
        .WithTags("Orders");

        return endpoints;
    }
}