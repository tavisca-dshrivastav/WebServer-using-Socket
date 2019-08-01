using System;
using System.Collections.Generic;
using System.Text;

namespace MySampleWebServer
{
    public class  MimeType
    {
        public static Dictionary<string, string> supportedMime = new Dictionary<string, string>
            {
                {".html" , "text/html"},
                {".htm" , "text/htm"},
                {".png" , "image/png"},
                {".jpeg" , "image/jpeg"},
                {".jpg" , "image/jpg"},
                {".bmp" , "image/bmp"},
                {".css" , "text/css"},
                {".js" , "text/js"},
                {".mp3" , "audio/mp3"},
                {".mp4" , "video/mp4"},
                {".wav" , "audio/wav"}

            };
    }
}
