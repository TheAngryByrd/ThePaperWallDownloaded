using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface IImageDownloader
    {
        void Download(string directory, string image);
    }
}
