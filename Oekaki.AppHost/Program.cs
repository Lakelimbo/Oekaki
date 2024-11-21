var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var coreApi = builder.AddProject<Projects.Oekaki_Core>("coreapi").WithExternalHttpEndpoints();
var frontend = builder
    .AddNpmApp("frontend", "../Oekaki.Web")
    .WaitFor(coreApi)
    .WithReference(coreApi)
    .WaitFor(cache)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
