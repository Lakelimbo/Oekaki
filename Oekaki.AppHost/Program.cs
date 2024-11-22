var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("cache");
var postgres = builder.AddPostgres("postgres").AddDatabase("oekakidb");

var core = builder
    .AddProject<Projects.Oekaki_Core>("coreapi")
    .WaitFor(postgres)
    .WithReference(postgres)
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.Oekaki_MigrationService>("migrations").WithReference(postgres);

var frontend = builder
    .AddNpmApp("frontend", "../Oekaki.Web")
    .WaitFor(core)
    .WithReference(core)
    .WaitFor(postgres)
    .WithReference(postgres)
    .WaitFor(redis)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
