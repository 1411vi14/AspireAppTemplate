using Projects;

using Scalar.Aspire;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");

var webapi = builder.AddProject<Web_Api>("web-api")
	.WithReference(postgres)
	.WaitFor(postgres);

builder.AddScalarApiReference()
	.WithApiReference(webapi);

await builder.Build().RunAsync();