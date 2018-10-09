using System;
using System.Net;
using System.Net.Http;

namespace carros_2.util
{
    public class ProxyConfig
    {
        private readonly string USER = "s017998";
        private readonly string PASS = "#781460simi";
        private readonly string URI = "http://pien.sanepar.com.br:9090";

        public HttpClientHandler CreateSaneparProxyConfig()
        {

            WebProxy proxy = new WebProxy()
            {
                Address = new Uri(URI),
                BypassProxyOnLocal = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                            userName: USER,
                            password: PASS),
            };
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Proxy = proxy,
            };

            return httpClientHandler;
        }
    }
}
