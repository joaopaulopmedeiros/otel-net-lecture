namespace Demo.Api.IoC;

public static class ValidatorInjector
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<OrderPostRequest>, OrderPostRequestValidator>();
        return services;
    }
}