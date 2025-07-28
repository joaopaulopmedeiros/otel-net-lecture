namespace Demo.Api.Documentation.Extensions;

public static class DocumentationExtensions
{
    public static IServiceCollection AddDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Orders API",
            Version = "v1",
            Description = "Simple demo order api"
        }));

        return services;
    }

    public static WebApplication UseDocumentation(this WebApplication app)
    {
        app.UseSwagger(opt => opt.RouteTemplate = "openapi/{documentName}.json");
        app.MapScalarApiReference("/docs",
            opt =>
            {
                opt.Title = "API Documentation";
                opt.Theme = ScalarTheme.DeepSpace;
                opt.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Curl);
            }
        );

        return app;
    }
}