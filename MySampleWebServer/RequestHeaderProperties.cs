using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    public class RequestHeaderProperties
    {
        public RequestHeaderProperties(string host, string uRL, string type, string referer)
        {
            Host = host;
            URL = uRL;
            Type = type;
            Referer = referer;
        }

        public string Host { get; private set; }
        public string URL { get; private set; }
        public string Type { get; private set; }
        public string Referer { get; private set; }

    }
}
