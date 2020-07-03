// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(), 
            };

        public static IEnumerable<ApiResource> Apis =>
            new[]
            {
                new ApiResource("AntBlazorApp.ServerAPI", "Demo Api", new []{ JwtClaimTypes.Name, JwtClaimTypes.Email })
            };

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
            };

    }
}