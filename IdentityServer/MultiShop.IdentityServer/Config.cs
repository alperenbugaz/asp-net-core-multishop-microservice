using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources =>new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes = { "CatalogFullPermission","CatalogReadPermission" }},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"} },
            new ApiResource("ResourceCargo"){Scopes={ "CargoFullPermission" } },
            new ApiResource("ResourceOrder"){Scopes = { "OrderFullPermission" }},
            new ApiResource("ResourceBasket"){Scopes = { "BasketFullPermission" }},
            new ApiResource("ResourcePayment"){Scopes = { "PaymentFullPermission" }},
            new ApiResource("ResourceComment"){Scopes = { "CommentFullPermission" }},
            new ApiResource("ResourceImages"){Scopes = { "ImagesFullPermission" }},
            new ApiResource("ResourceOcelot"){Scopes = { "OcelotFullPermission" }},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)


        };  

    public static IEnumerable<IdentityResource> IdentityResources =>new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

    public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission", "Full access to catalog"),
            new ApiScope("CatalogReadPermission", "Read access to catalog"),
            new ApiScope("DiscountFullPermission", "Full access to discount"),
            new ApiScope("OrderFullPermission", "Full access to order"),
            new ApiScope("CargoFullPermission", "Full access to cargo"),
            new ApiScope("BasketFullPermission", "Full access to basket"),
            new ApiScope("PaymentFullPermission", "Full access to payment"),
            new ApiScope("CommentFullPermission", "Full access to comment"),
            new ApiScope("ImagesFullPermission", "Full access to images"),
            new ApiScope("OcelotFullPermission", "Full access to ocelot operation"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)

        };

    public static IEnumerable<Client> Clients => new Client[]
        {   
            //Visitor
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("MultiShopManagerSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "PaymentFullPermission", "CommentFullPermission", "ImagesFullPermission", "BasketFullPermission", "OcelotFullPermission" }
            },
            //Manager
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("MultiShopManagerSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", 
                    "PaymentFullPermission", "CommentFullPermission", "ImagesFullPermission", "OcelotFullPermission"
                ,
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile}
            },
            //Admin
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("MultiShopManagerSecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "CatalogReadPermission", "DiscountFullPermission", 
                    "OrderFullPermission","CargoFullPermission","BasketFullPermission" , "PaymentFullPermission","CommentFullPermission", "ImagesFullPermission","OcelotFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime = 3600,


            }


        };

}
