// Copyright (c) Nick Frederiksen. All Rights Reserved.

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QVZ.Api.Constants.Authorization;
using QVZ.DAL;

namespace QVZ.Api
{
	public partial class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			this.SetupAuthorization(services);

			services.AddAutoMapper(this.GetType().Assembly);

			services.AddDatabaseContext(this.Configuration.GetConnectionString("QVZDB"));

			services.AddControllers();

			this.SetupSwaggerService(services);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers()
				.RequireAuthorization(new AuthorizeAttribute(Scopes.Read)); ;
			});

			this.SetupSwaggerUi(app, env);
		}
	}
}
