using System;

namespace MySampleWebServer
{
    public class Request
    {
        public Request(string type, string uRL, string host)
        {
            Type = type;
            URL = uRL;
            Host = host;
        }

        public static Request GetRequest(String request)
        {
            if (String.IsNullOrEmpty(request))
                return null;
            String[] tokens = request.Split(' ');
            String type = tokens[0];
            String url = tokens[1];
            String host = tokens[3].Substring(0, tokens[3].IndexOf('\n'));
            String referer = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "Referer:")
                {
                    referer = tokens[i + 1];
                    break;
                }
            }
            Console.WriteLine($"{type} {url} @ {host} \nReferer: {referer}");
            return new Request(type, url, host);
        }

        public String Type { get; set; }
        public String URL { get; set; }
        public String Host { get; set; }

    }
}
