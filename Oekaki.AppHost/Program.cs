var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("postgres")
    .WithDataVolume(isReadOnly: false)
    .AddDatabase("oekakidb");

builder.AddProject<Projects.Oekaki_MigrationService>("migrations").WithReference(postgres);

var redis = builder.AddRedis("cache");

var core = builder
    .AddProject<Projects.Oekaki_Core>("coreapi")
    .WaitFor(postgres)
    .WithReference(postgres)
    .WithExternalHttpEndpoints();

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
