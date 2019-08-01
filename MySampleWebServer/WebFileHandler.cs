using System;
using System.IO;
using System.Collections.Generic;

namespace MySampleWebServer
{
    public class WebFileHandler
    {

        private static DirectoryInfo _defaultDirectory = new DirectoryInfo(Environment.CurrentDirectory + HTTPServer.WEB_DIR);
        private static string _file;
        private static FileInfo _fileInfo;

        private static HashSet<string> _defaultFiles = new HashSet<string>
        {
            "index.html",
            "index.htm",
            "default.html",
            "default.htm"
        };
        public WebFileHandler(string file, FileInfo fileInfo)
        {
            _file = file;
            _fileInfo = fileInfo;
        }
        public static WebFileHandler From(Request request)
        {
            String file = Environment.CurrentDirectory + HTTPServer.WEB_DIR + request.URL;
            FileInfo f = new FileInfo(file);
            return new WebFileHandler(file, f);
        }
        public static FileInfo GetFileInfo() => _fileInfo;
        public static bool IsFileExist() => _fileInfo.Exists;
        public static string GetFileExtension() => Path.GetExtension(_file);

        public static bool IsFileRequested() => _fileInfo.Extension.Contains(".");
        
        public static FileInfo GetDefaultFileInfo() => _fileInfo;

        public static bool IsDefaultFileExist()
        {
            FileInfo[] files = _defaultDirectory.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                if (_defaultFiles.Contains(fileInfo.Name))
                {
                    _fileInfo = fileInfo;
                    return true;
                }
            }
            return false;
        }
    }
}
