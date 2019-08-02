using System;

namespace MySampleWebServer
{
    public class HTTPParser
    {
        public static RequestHeaderProperties ParseHttpRequest(String request)
        {
            String[] tokens = request.Split(' ');
            string type = tokens[0];
            string uRL = tokens[1];
            string host = tokens[3].Substring(0, tokens[3].IndexOf('\n'));
            string referer = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == "Referer:")
                {
                    referer = tokens[i + 1];
                    break;
                }
            }
            return new RequestHeaderProperties(host, uRL, type, referer);
        }

    }
}
