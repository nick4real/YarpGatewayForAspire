var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.User_API>("user-api");

builder.AddProject<Projects.Product_API>("product-api");

builder.Build().Run();
