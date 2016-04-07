using System.Web.Http;
using IQ.Santos.Ngo.Beertap.WebApi.Infrastructure;

namespace IQ.Santos.Ngo.Beertap.WebApi
{

    public class HttpServerFactory
    {
        public HttpServer Create()
        {
            return new HttpServer(GetHttpConfiguration());
        }

        private static HttpConfiguration GetHttpConfiguration()
        {
            var config = new HttpConfiguration();
            BootStrapper.Initialize(config);
            return config;
        }
    }
}