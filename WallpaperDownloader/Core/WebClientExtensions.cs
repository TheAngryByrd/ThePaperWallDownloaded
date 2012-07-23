using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core
{


    public static class WebClientExtensions
    {
        public static Task DownloadFileTaskAsync(
           this WebClient wc,
           string address,
           string fileName,
           IProgress<DownloadProgressChangedEventArgs> progress)
        {
            wc.DownloadProgressChanged += (s, e) =>
            {
                progress.Report(e);
            };

            return wc.DownloadFileTaskAsync(address, fileName);

        }


    }

}
