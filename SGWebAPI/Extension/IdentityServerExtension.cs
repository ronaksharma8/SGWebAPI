using IdentityServer4.Models;
using IdentityServer4.Test;

namespace SGWebAPI.Extension
{
    public static class IdentityServerExtension
    {
        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId = "reactClient",
                ClientName = "React Client",
                AllowedGrantTypes = GrantTypes.ClientCredentials ,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "SGWebAPI" }
            }
        };
        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[] { new ApiScope("SGWebAPI", "SG Web API") };
        public static IEnumerable<ApiResource> ApiResources => Array.Empty<ApiResource>();
        public static IEnumerable<IdentityResource> IdentityResources => Array.Empty<IdentityResource>();
        public static IEnumerable<TestUser> TestUsers => Array.Empty<TestUser>();
    }
}
