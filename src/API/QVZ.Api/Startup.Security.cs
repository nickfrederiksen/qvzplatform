// Copyright (c) Nick Frederiksen. All Rights Reserved.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QVZ.Api.Constants.Authorization;
using QVZ.Integrations.Azure.AzureAD;

namespace QVZ.Api
{
	public partial class Startup
	{
		private void SetupAuthorization(IServiceCollection services)
		{
			services
				.AddAzureADAuthentication(options => this.Configuration.Bind("AzureAd", options))
				.AddAzureADAuthorization(options =>
				{
					options.AddScopePolicy(Scopes.Player);
					options.AddScopePolicy(Scopes.Creator);
				});
		}
	}
}
