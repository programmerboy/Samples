using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;
using WebAPI.Helpers;

namespace Samples.WebAPI.Providers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class MyCorsPolicyAttribute : Attribute, ICorsPolicyProvider
    {
        private readonly char SEPERATOR = CustomConfig.SEPERATOR;
        
        private CorsPolicy _policy;

        public MyCorsPolicyAttribute()
        {
            // Create a CORS policy.
            _policy = new CorsPolicy { SupportsCredentials = true };

            // Add allowed ORIGINS.
            foreach (var item in CustomConfig.ORIGINS.Split(SEPERATOR)) { _policy.Origins.Add(item.Trim()); }
            // Add allowed HEADERS.
            foreach (var item in CustomConfig.HEADERS.Split(SEPERATOR)) { _policy.Headers.Add(item.Trim()); }
            // Add allowed METHODS.
            foreach (var item in CustomConfig.METHODS.Split(SEPERATOR)) { _policy.Methods.Add(item.Trim()); }
            // Add allowed EXPOSEDHEADERS.
            foreach (var item in CustomConfig.EXPOSEDHEADERS.Split(SEPERATOR)) { _policy.ExposedHeaders.Add(item.Trim()); }
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            return Task.FromResult(_policy);
        }
    }
}