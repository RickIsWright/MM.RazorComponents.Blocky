using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using MM.RazorComponents.Blocky.App.Services;

namespace MM.RazorComponents.Blocky.App
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			// Example of a data service
			services.AddSingleton<WeatherForecastService>();
		}

		public void Configure(IComponentsApplicationBuilder app)
		{
			app.AddComponent<App>("app");
		}
	}
}
