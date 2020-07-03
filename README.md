# Template of AntDesign Blazor

# AntDesignWasmHostedPwaOidc
 Blazor WebAssembly use AddOidcAuthentication() to call secured WebApis
### 0.Oidc Server (eg. IdentityServer4 with abp)
* https://localhost:5001

### 1.Client (ie. this repo)
* https://localhost:44326
```
        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "antBlazorApp.Client",
                    AllowedGrantTypes =   GrantTypes.Implicit ,

                    ClientSecrets =
                    {
                        new Secret("".Sha256())
                    },

                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "AntBlazorApp.ServerAPI"
                    },
                    RedirectUris =
                    {
                        "https://localhost:44326/authentication/login-callback"
                    },
                    PostLogoutRedirectUris =
                    {
                        "https://localhost:44326/authentication/logout-callback"
                    }
                },
            }
```
### 2. AddOidcAuthentication
```
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Oidc", options.ProviderOptions); 
            });
```
appsettings.json
```
{
  "Oidc": {
    "Authority": "https://localhost:5001",
    "ClientId": "antBlazorApp.Client",
    "RedirectUri": "https://localhost:44326/authentication/login-callback",
    "PostLogoutRedirectUri": "https://localhost:44326/authentication/logout-callback",
    "ResponseType": "id_token token",
    "DefaultScopes": [
      "openid",
      "profile"
    ]
  } 
}
```

