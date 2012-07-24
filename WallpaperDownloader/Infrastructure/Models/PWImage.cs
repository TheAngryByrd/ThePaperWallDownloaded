using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Infrastructure.Models
{
    public class PWImage
    {
        public string imageUrl { get; set; }
        public string imageName { get { return GetImageFileName(imageUrl); } }
        public Theme Theme { get; set; }
        public Progress<DownloadProgressChangedEventArgs> progress { get; set; }

        public string GetImageFileName(string imageUrl)
        {
            Uri uri = new Uri(imageUrl);
            string filename = Path.GetFileName(uri.LocalPath);
            return filename;
        }
    }
}
