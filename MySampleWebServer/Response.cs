using System;
using System.Collections.Generic;
using System.IO;

namespace MySampleWebServer
{
    public class Response
    {
        private Byte[] _data = null;
        private string _status;
        private string _mime;


        public Response(String status, string mime, Byte[] data)
        {
            _data = data;
            _status = status;
            _mime = mime;

        }

        public static Response From(Request request)
        {
            WebFileHandler webFileHandler = WebFileHandler.From(request);

            if (ErrorRequest.IsRequestWithError(request))
                return ErrorResponse.GetErrorResponse(request);

            if (WebFileHandler.IsFileRequested() == true)
                return HadleRequestedFile(request);

            if (WebFileHandler.IsDefaultFileExist() == true)
                return HandleRequestedDirectory();

            return ErrorResponse.GetErrorResponse(request);
        }

        private static Response HandleRequestedDirectory()
        {
            FileInfo defaultFile = WebFileHandler.GetDefaultFileInfo();
            string extention = Path.GetExtension(defaultFile.ToString());
            return MakeFromFile(defaultFile, extention);
        }

        private static Response HadleRequestedFile(Request request)
        {
            if (WebFileHandler.IsFileExist() == true)
                return MakeFromFile(WebFileHandler.GetFileInfo(), WebFileHandler.GetFileExtension());
            return ErrorResponse.GetErrorResponse(request);
        }

        private static Response MakeFromFile(FileInfo f, string mimeType)
        {
            FileStream fs = f.OpenRead();
            BinaryReader reader = new BinaryReader(fs);
            Byte[] d = new Byte[fs.Length];
            reader.Read(d, 0, d.Length);
            Console.WriteLine(d.Length);
            fs.Close();
            if (MimeType.supportedMime.ContainsKey(mimeType) == false)
                return ErrorResponse.MakeNullRequest();
            return new Response("200 OK", MimeType.supportedMime[mimeType], d);
        }


        public void Post(Stream stream)
        {
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine(string.Format("{0} {1}\r\nServer: {2}\r\nContent-Type: {3}\r\nAccept-Ranges: bytes\r\nContent-Length: {4}\r\n", HTTPServer.VERSION, _status, HTTPServer.NAME, _mime, _data.Length));
            writer.Flush();
            stream.Write(_data, 0, _data.Length);
        }
    }
}
