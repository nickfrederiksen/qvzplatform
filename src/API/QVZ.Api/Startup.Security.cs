// Copyright (c) Nick Frederiksen. All Rights Reserved.

using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QVZ.Api.Constants.Authorization;

namespace QVZ.Api
{
	public partial class Startup
	{
		private void SetupAuthorization(IServiceCollection services)
		{
			this.SetupAuthentication(services);

			services.AddAuthorization(o =>
			{
				o.AddPolicy(Scopes.Read, new AuthorizationPolicyBuilder()
				   .RequireAuthenticatedUser()
				   .RequireAssertion(context =>
				   {
					   var claim = context.User.FindFirstValue("http://schemas.microsoft.com/identity/claims/scope") ?? string.Empty;
					   var scopes = claim.Split(" ");
					   return scopes.Contains(Scopes.Read, StringComparer.OrdinalIgnoreCase);
				   })
				   .Build());

				o.AddPolicy(Scopes.Write, new AuthorizationPolicyBuilder()
				   .RequireAuthenticatedUser()
				   .RequireAssertion(context =>
				   {
					   var claim = context.User.FindFirstValue("http://schemas.microsoft.com/identity/claims/scope") ?? string.Empty;
					   var scopes = claim.Split(" ");
					   return scopes.Contains(Scopes.Write, StringComparer.OrdinalIgnoreCase);
				   })
				   .Build());

				o.AddPolicy(Scopes.Admin, new AuthorizationPolicyBuilder()
				   .RequireAuthenticatedUser()
				   .RequireAssertion(context =>
				   {
					   var claim = context.User.FindFirstValue("http://schemas.microsoft.com/identity/claims/scope") ?? string.Empty;
					   var scopes = claim.Split(" ");
					   return scopes.Contains(Scopes.Admin, StringComparer.OrdinalIgnoreCase);
				   })
				   .Build());
			});
		}

		private void SetupAuthentication(IServiceCollection services)
		{
			services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
							.AddAzureADBearer(options => this.Configuration.Bind("AzureAd", options));

			services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
			{
				// This is an Azure AD v2.0 Web API
				options.Authority += "/v2.0";

				// The valid audiences are both the Client ID (options.Audience) and api://{ClientID}
				//options.TokenValidationParameters.ValidAudiences = new string[] { options.Audience, $"api://{options.Audience}" };

			});
		}
	}
}
