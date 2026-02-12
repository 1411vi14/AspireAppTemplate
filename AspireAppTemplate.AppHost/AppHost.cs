var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
var redis = builder.AddRedis("redis");

builder.AddProject<Projects.Web_Api>("web-api")
	.WithReference(postgres)
	.WaitFor(postgres)
	.WaitFor(redis);

await builder.Build().RunAsync();
