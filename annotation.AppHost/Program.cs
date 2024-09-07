var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.annotation_Api>("api")
    .WithExternalHttpEndpoints();

builder.AddNpmApp("frontend", "../annotation.Frontend")
    .WithReference(api)
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();