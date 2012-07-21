using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core
{
    public class PWImage
    {
        public string imageUrl { get; set; }
        public string imageName { get { return GetImageFileName(imageUrl); } }

        public string GetImageFileName(string imageUrl)
        {
            Uri uri = new Uri(imageUrl);
            string filename = Path.GetFileName(uri.LocalPath);
            return filename;
        }
    }
}
