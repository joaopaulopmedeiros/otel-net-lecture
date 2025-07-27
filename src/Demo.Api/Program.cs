var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<OrderPostRequest>, OrderPostRequestValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
{
    Title = "Orders API",
    Version = "v1",
    Description = "Simple demo order api"
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
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
}

app.MapOrderPostEndpoint();

app.UseHttpsRedirection();

app.Run();
