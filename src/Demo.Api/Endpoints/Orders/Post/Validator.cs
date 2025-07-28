namespace Demo.Api.Endpoints.Orders.Post;

public class OrderPostRequestValidator : AbstractValidator<OrderPostRequest>
{
    public OrderPostRequestValidator()
    {
        RuleFor(x => x.Price)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("Price must not be negative");
    }
}

public static class OrderPostRequestValidatorExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<OrderPostRequest>, OrderPostRequestValidator>();
        return services;
    }
}