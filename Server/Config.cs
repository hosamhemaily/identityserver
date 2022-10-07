using IdentityServer4.Models;

namespace Server
{
	public class Config
	{
        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("Api1.read"), new ApiScope("Api1.write"),new ApiScope("Api2.read"), new ApiScope("Api2.write") };
        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("Api1")
                {
                    Scopes = new List<string> { "Api1.read", "Api1.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret1".Sha256()) },
                    UserClaims = new List<string> { "role" ,"roletype"}
                } ,
                new ApiResource("Api2")
                {
                    Scopes = new List<string> { "Api2.read", "Api2.write" },
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret2".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "Api1.client",
                    //ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedScopes = { "Api1.read", "Api1.write" }
                },
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "Api2.client",
                    ClientSecrets = { new Secret("ClientSecret2".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    RedirectUris = { "https://localhost:5444/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5444/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "Api2.read", "Api2.write" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },
            };
    }
}
