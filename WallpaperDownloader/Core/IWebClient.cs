using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Core
{
    public interface IWebClient : IDisposable
    {
        void DownloadFile(string address, string fileName);
    }

    public class WebClientWrapper : WebClient, IWebClient
    {
    
    }
}
