using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Samples.WebAPI.Handlers
{
    public class MyMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return base.SendAsync(request, cancellationToken);
        }
    }
}