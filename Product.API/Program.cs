var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapGet("/products", () =>
{
    var products = new Dictionary<string, string>()
    {
        { "1", "Car" },
        { "2", "Keychain" },
        { "3", "Fork" },
    };
    return Results.Ok(products);
});

app.Run();