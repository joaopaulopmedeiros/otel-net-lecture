var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<OrderPostRequest>, OrderPostRequestValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapOrderPostEndpoint();

app.UseHttpsRedirection();

app.Run();
