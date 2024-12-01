var builder = DistributedApplication.CreateBuilder(args);

var user_api = builder.AddProject<Projects.User_API>("user-api");

var product_api = builder.AddProject<Projects.Product_API>("product-api");

builder.AddProject<Projects.Yarp_Gateway>("yarp-gateway")
    .WithHttpEndpoint(port: 8001, name: "yarp")
    .WithReference(user_api)
    .WithReference(product_api);

builder.Build().Run();