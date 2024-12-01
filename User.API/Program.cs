var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapGet("/users", () =>
{
    var users = new Dictionary<string, string>()
    {
        { "1", "Mike" },
        { "2", "Debian" },
        { "3", "Alucard" },
    };
    return Results.Ok(users);
});

app.Run();