using System.Net.Http;
using System.Web.Http.Cors;

namespace Samples.WebAPI.Providers
{
    public class MyCorsPolicyFactory : ICorsPolicyProviderFactory
    {
        ICorsPolicyProvider _provider = new MyCorsPolicyProvider();

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _provider;
        }
    } 
}