var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidators();
builder.Services.AddDocumentation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDocumentation();
}

app.MapOrderPostEndpoint();

app.UseHttpsRedirection();

app.Run();
