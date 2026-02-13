using Projects;

using Scalar.Aspire;

using KeycloakResource = Keycloak.Hosting.KeycloakResource;

var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres");
IResourceBuilder<KeycloakResource> keycloak = builder.AddKeycloak("keycloak", postgres)
	.WaitFor(postgres);

var webapi = builder.AddProject<Web_Api>("web-api")
	.WithReference(postgres)
	.WaitFor(postgres);

builder.AddScalarApiReference()
	.WithApiReference(webapi);

await builder.Build().RunAsync();