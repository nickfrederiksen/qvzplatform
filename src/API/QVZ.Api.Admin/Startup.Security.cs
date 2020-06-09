using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QVZ.Api.Admin.Constants;
using QVZ.Integrations.Azure.AzureAD;

namespace QVZ.Api.Admin
{
	public partial class Startup
	{
		private void SetupAuthorization(IServiceCollection services)
		{
			services
				.AddAzureADAuthentication(options => this.Configuration.Bind("AzureAd", options))
				.AddAzureADAuthorization(options =>
				{
					options.AddScopePolicy(Scopes.Admin);
				});
		}
	}
}
