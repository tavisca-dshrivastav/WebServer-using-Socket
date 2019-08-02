using System;

namespace MySampleWebServer
{
    public class Request
    {
        private Request(RequestHeaderProperties requestHeaderProperties)
        {
            Type = requestHeaderProperties.Type;
            URL = requestHeaderProperties.URL;
            if (requestHeaderProperties.URL.EndsWith("//"))
                URL = requestHeaderProperties.URL.Substring(0,requestHeaderProperties.URL.Length - 1);
            Host = requestHeaderProperties.Host;
        }

        public static Request GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            RequestHeaderProperties requestHeaderProperties = HTTPParser.ParseHttpRequest(request);            
            Console.WriteLine($"{requestHeaderProperties.Type} {requestHeaderProperties.URL} @ {requestHeaderProperties.Host} \nReferer: {requestHeaderProperties.Referer}");
            return new Request(requestHeaderProperties);
        }

        public String Type { get; set; }
        public String URL { get; set; }
        public String Host { get; set; }

    }
}
