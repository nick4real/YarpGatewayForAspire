var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddReverseProxy()
    // Using load from memory, so now we can get connection strings from the environment variables
    .LoadFromMemory(ReverseProxy.Routes, ReverseProxy.Clusters);

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.MapReverseProxy();

app.Run();