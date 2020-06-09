using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace QVZ.Integrations.Azure.AzureAD
{
	public static class AzureADConfigurator
	{
		public static IServiceCollection AddAzureADAuthentication(this IServiceCollection services, Action<AzureADOptions> adConfiguration)
		{
			services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
							.AddAzureADBearer(adConfiguration);

			services.Configure<JwtBearerOptions>(AzureADDefaults.JwtBearerAuthenticationScheme, options =>
			{
				options.Authority += "/v2.0";
			});

			return services;
		}

		public static IServiceCollection AddAzureADAuthorization(this IServiceCollection services, Action<AuthorizationOptions> configureAuthentication)
		{
			services.AddAuthorization(configureAuthentication);

			return services;
		}

		public static void AddScopePolicy(this AuthorizationOptions authenticationOptions, string scopeName)
		{
			authenticationOptions.AddPolicy(scopeName, new AuthorizationPolicyBuilder()
					  .RequireAuthenticatedUser()
					  .RequireAssertion(context =>
					  {
						  var claim = context.User.FindFirstValue("http://schemas.microsoft.com/identity/claims/scope") ?? string.Empty;
						  var scopes = claim.Split(" ");
						  return scopes.Contains(scopeName, StringComparer.OrdinalIgnoreCase);
					  })
					  .Build());
		}
	}
}
