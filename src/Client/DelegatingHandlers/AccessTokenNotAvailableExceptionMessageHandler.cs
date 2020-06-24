using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace AntDesignTemplate.Client.DelegatingHandlers
{
    public class AccessTokenNotAvailableExceptionMessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                return await base.SendAsync(request, cancellationToken);
            }
            catch (AccessTokenNotAvailableException exception)
            {
                exception.Redirect();
                return new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}