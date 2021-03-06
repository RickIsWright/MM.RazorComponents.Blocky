﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MM.RazorComponents.Blocky.Server
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddRazorComponents<App.Startup>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			
			app.UseSignalR(route => route.MapHub<BlazorHub>(BlazorHub.DefaultPath, o =>
			{
				o.ApplicationMaxBufferSize = 0 ; // larger size
				o.TransportMaxBufferSize = 0 ; // larger size
			}));
			app.UseRazorComponents<App.Startup>();
			Console.WriteLine("Launch");
		}
	}
}
