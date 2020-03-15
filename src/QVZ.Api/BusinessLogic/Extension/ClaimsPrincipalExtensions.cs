namespace System.Security.Claims
{
	internal static class ClaimsPrincipalExtensions
	{
		public static string GetObjectIdentifier(this ClaimsPrincipal user)
		{
			var objectIdentifier = user.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
			return objectIdentifier;
		}
	}
}
