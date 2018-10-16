using carros_2.config;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace carros_2.util
{
    public class ProxyConfig
    {
        private readonly string CONFIG_FILE = "config.json";


        public HttpClientHandler CreateCompanyProxyConfig()
        {
            string json = ResourceLoader.GetEmbeddedResourceString(Assembly.GetAssembly(typeof(ResourceLoader)), CONFIG_FILE);

            var config = JsonConvert.DeserializeObject<ConfigModel>(json);

            if (config.Proxy != null && !string.IsNullOrEmpty(config.Proxy.Url))
            {

                string uri = config.Proxy.Url + (config.Proxy.Port > 0 ? ":" + config.Proxy.Port : "");

                WebProxy proxy = new WebProxy()
                {
                    Address = new Uri(uri),
                    BypassProxyOnLocal = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                                userName: config.Proxy.Username,
                                password: config.Proxy.Password),
                };
                HttpClientHandler httpClientHandler = new HttpClientHandler()
                {
                    Proxy = proxy,
                };

                return httpClientHandler;
            }
            else
            {
                return new HttpClientHandler();
            }

            
        }
    }
}
