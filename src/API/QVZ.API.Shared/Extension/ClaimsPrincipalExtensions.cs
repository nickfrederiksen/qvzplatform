namespace System.Security.Claims
{
	internal static class ClaimsPrincipalExtensions
	{
		public static string GetObjectIdentifier(this ClaimsPrincipal user)
		{
			var objectIdentifier = user.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
			return objectIdentifier;
		}
	}
}
