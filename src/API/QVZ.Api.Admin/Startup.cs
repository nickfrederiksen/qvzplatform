using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QVZ.Api.Admin.Constants;
using QVZ.DAL;

namespace QVZ.Api.Admin
{
	public partial class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			this.SetupAuthorization(services);

			services.AddHttpContextAccessor();

			services.AddAutoMapper(
				(provider, options) =>
				{
					options.ConstructServicesUsing(provider.GetService);
				},
				this.GetType().Assembly);

			services.AddDatabaseContext(this.Configuration.GetConnectionString("QVZDB"));

			services.AddCors();

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
			app.UseCors(configure =>
			{
				configure.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers()
				.RequireAuthorization(new AuthorizeAttribute(Scopes.Admin));
			});

			this.SetupSwaggerUi(app, env);
		}
	}
}
