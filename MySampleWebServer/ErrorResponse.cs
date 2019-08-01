using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MySampleWebServer
{
    public class ErrorResponse
    {
        public static Response MakeMethodNotAllowed()
        {
            Byte[] d = GetErrorResponseStream("405.html");
            return new Response("405 Method Not Allowed", "text/html", d);
        }

        private static Byte[] GetErrorResponseStream(string fileName)
        {

            String file = Environment.CurrentDirectory + HTTPServer.MSG_DIR + fileName;
            FileInfo fi = new FileInfo(file);
            FileStream fs = fi.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            return d;
        }

        public static Response GetErrorResponse(Request request)
        {
            if (request == null)
                return MakeNullRequest();
            if (request.Type != "GET")
                return MakeMethodNotAllowed();
            return MakePageNotFound();
        }

        
        public static Response MakePageNotFound()
        {
            Byte[] d = GetErrorResponseStream("404.html");
            return new Response("404 Page Not Found", "text/html", d);
        }

        public static Response MakeNullRequest()
        {
            Byte[] d = GetErrorResponseStream("400.html");
            return new Response("400 Bad Request", "text/html", d);
        }
    }
}
