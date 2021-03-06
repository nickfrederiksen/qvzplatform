﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QVZ.Api.Admin.Constants;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace QVZ.Api.Admin
{
	public partial class Startup
	{
		private const string APIName = "QVZ Admin API";

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
					Description = "Admin API",
				});

				var filePath = Path.Combine(AppContext.BaseDirectory, "QVZ.Api.Admin.xml");
				c.IncludeXmlComments(filePath);

				var instance = this.Configuration.GetSection("AzureAd:Instance").Value;
				var tenant = this.Configuration.GetSection("AzureAd:TenantId").Value;
				var clientId = this.Configuration.GetSection("AzureAd:ClientId").Value;
				var authority = $"{instance}{tenant}/oauth2/v2.0";

				var adminScope = $"api://{clientId}/{Scopes.Admin}";

				var scopes = new string[]
						{
							adminScope,
						};

				AddOAuth2Security(c, authority, adminScope);

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

		private static void AddOAuth2Security(SwaggerGenOptions c, string authority, string adminScope)
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
								{ adminScope, "Admin access" },
							},
					},
				},
			};
			c.AddSecurityDefinition("oauth2", oauthScheme);
		}
	}
}
