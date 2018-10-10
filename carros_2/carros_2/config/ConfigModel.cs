using System;
using System.Collections.Generic;
using System.Text;

namespace carros_2.config
{
    public class ConfigModel
    {
        public ProxyModel Proxy { get; set; }
    }

    public class ProxyModel
    {
        public string Url { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
