using System;
using System.IO;
using System.Collections.Generic;

namespace MySampleWebServer
{
    public class WebFileHandler
    {

        private static DirectoryInfo _defaultDirectory = new DirectoryInfo(Environment.CurrentDirectory + HTTPServer.WEB_DIR);
        private string _file;
        private FileInfo _fileInfo;

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
        public static WebFileHandler GetWebFileHandler(Request request)
        {
            try
            {
                String file = Environment.CurrentDirectory + HTTPServer.WEB_DIR + request.URL;

                FileInfo f = new FileInfo(file);
                return new WebFileHandler(file, f);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Web File Handler Error -> {e.Message}");
                return null;
            }
        }
        public FileInfo GetFileInfo() => _fileInfo;
        public bool IsFileExist() => _fileInfo.Exists;
        public string GetFileExtension() => Path.GetExtension(_file);

        public bool IsFileRequested() => _fileInfo.Extension.Contains(".");
        
        public FileInfo GetDefaultFileInfo() => _fileInfo;

        public bool IsDefaultFileExist()
        {
            FileInfo[] files = _defaultDirectory.GetFiles();
            DirectoryInfo di = new DirectoryInfo(_file);

            if (di.Exists == false)
                return false;
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
