using System;
using System.Net.Http;
using System.Threading.Tasks;
using AntDesignTemplate.Client.DelegatingHandlers;
using AntDesignTemplate.Client.Services;
using AntDesignTemplate.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AntDesignTemplate.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("AntDesignTemplate.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()
                .AddHttpMessageHandler<AccessTokenNotAvailableExceptionMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("AntDesignTemplate.ServerAPI"));

            //builder.Services.AddApiAuthorization();
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("Oidc", options.ProviderOptions); 
            });

            builder.Services.AddAntDesign();
            builder.Services.AddScoped<ILoginService, LoginService>();

            await builder.Build().RunAsync();
        }
    }
}