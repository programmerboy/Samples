using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.WebAPI.Helpers
{
    public class CustomTextResult : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;

        public CustomTextResult(string value, HttpRequestMessage request)
        {
            _value = value;
            _request = request;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value, Encoding.UTF8),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
}