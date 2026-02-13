namespace Web.Api.Extensions;

internal static class HostApplicationBuilderExtensions
{
	public static IHostApplicationBuilder AddOptions<TOptions>(this IHostApplicationBuilder builder, string sectionName)
		where TOptions : class
	{
		builder.Services.Configure<TOptions>(builder.Configuration.GetSection(sectionName));
		return builder;
	}
}