using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Samples.WebAPI.Helpers
{
    public class CustomTextResultWithHeaders : IHttpActionResult
    {
        string _value;
        HttpRequestMessage _request;
        private Dictionary<string, string> _headers;

        public CustomTextResultWithHeaders(string value, HttpRequestMessage request, Dictionary<string, string> headers)
        {
            _value = value;
            _request = request;
            _headers = headers;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_value, Encoding.UTF8),
                RequestMessage = _request
            };

            foreach (KeyValuePair<string, string> kvp in _headers)
                response.Headers.Add(kvp.Key, kvp.Value);

            return Task.FromResult(response);
        }
    }
}