using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class WebClientImageDownloader: IImageDownloader
    {
        private readonly IWebClient _webClient;
        public WebClientImageDownloader(IWebClient webclient)
        {
            _webClient = webclient;
        }

        public void Download(string directory, string imageUrl)
        {
            using (_webClient)
            {
                _webClient.DownloadFile(imageUrl, directory);
            }
        }
    }
}
