// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QVZ.Api.Constants.Authorization;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QVZ.Api
{
	public partial class Startup
	{
		private const string APIName = "QVZ Platform API";

		/// <summary>
		/// Sets up the Swagger services.
		/// </summary>
		/// <param name="services">Service collection.</param>
		public void SetupSwaggerService(IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo()
				{
					Version = "v1",
					Title = APIName,
					Description = "Core API",
				});

				var filePath = Path.Combine(AppContext.BaseDirectory, "QVZ.Api.xml");
				c.IncludeXmlComments(filePath);

				var instance = this.Configuration.GetSection("AzureAd:Instance").Value;
				var tenant = this.Configuration.GetSection("AzureAd:TenantId").Value;
				var clientId = this.Configuration.GetSection("AzureAd:ClientId").Value;
				var authority = $"{instance}{tenant}/oauth2/v2.0";

				var readScope = $"api://{clientId}/{Scopes.Player}";
				var writeScope = $"api://{clientId}/{Scopes.Creator}";

				var scopes = new string[]
						{
							readScope,
							writeScope,
						};

				AddOAuth2Security(c, authority, readScope, writeScope);

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer",
							},
						},
						scopes
					},
					{
						new OpenApiSecurityScheme()
						{
							Reference = new OpenApiReference() {
								Type = ReferenceType.SecurityScheme,
								Id = "oauth2",
							},
						},
						scopes
					},
				});

				c.OperationFilter<SecurityRequirementsOperationFilter>();
			});
		}

		/// <summary>
		/// Sets up the Swagger UI.
		/// </summary>
		/// <param name="app">Application builder.</param>
		public void SetupSwaggerUi(IApplicationBuilder app, IWebHostEnvironment env)
		{
			var clientId = this.Configuration.GetSection("swagger:oauth:clientId").Value;

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.OAuthScopeSeparator(" ");
				if (env.IsDevelopment())
				{
					c.OAuthClientId(clientId);
					c.OAuthRealm(clientId);
				}

				c.RoutePrefix = string.Empty;

				c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{APIName} V1");
			});
		}

		private static void AddBearerSecurity(SwaggerGenOptions c, string[] scopes)
		{
			c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter your token in the text input below.",
				Name = "Authorization",
				Type = SecuritySchemeType.Http,
				Scheme = "bearer",
			});
		}

		private static void AddOAuth2Security(SwaggerGenOptions c, string authority, string readScope, string writeScope)
		{
			OpenApiSecurityScheme oauthScheme = new OpenApiSecurityScheme()
			{
				Description = "Azure AD token",
				Type = SecuritySchemeType.OAuth2,
				Flows = new OpenApiOAuthFlows()
				{
					Implicit = new OpenApiOAuthFlow()
					{
						AuthorizationUrl = new Uri($"{authority}/authorize"),
						Scopes = new Dictionary<string, string>()
							{
								{ readScope, "Read access" },
								{ writeScope, "Write access" },
							},
					},
				},
			};
			c.AddSecurityDefinition("oauth2", oauthScheme);
		}
	}
}
