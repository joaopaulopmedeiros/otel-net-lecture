namespace Demo.Api.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<OrderPostRequest>, OrderPostRequestValidator>();
        return services;
    }
}