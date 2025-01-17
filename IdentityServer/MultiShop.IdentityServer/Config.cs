using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources =>new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = { "CatalogFullPermission","CatalogReadPermission" }},
            new ApiResource("ResourceDiscount"){Scopes = { "DiscountFullPermission" }},
            new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" }}


        };  

    public static IEnumerable<IdentityResource> IdentityResources =>new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access to catalog"),
            new ApiScope("CatalogReadPermission", "Read access to catalog"),
            new ApiScope("DiscountFullPermission", "Full access to discount"),
            new ApiScope("OrderFullPermission", "Full access to order")
        };

    public static IEnumerable<Client> Clients => new Client[]
        {   
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("MultiShopVisitorSecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" }
            },
            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("MultiShopManagerSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission"}
            },
            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("MultiShopAdminSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", "OrderFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 3600,


            }


        };

}
