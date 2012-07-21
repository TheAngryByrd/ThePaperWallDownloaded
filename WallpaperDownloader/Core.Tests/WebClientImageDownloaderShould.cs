using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Core.Tests
{
    [TestClass]
    public class WebClientImageDownloaderShould
    {
        [TestMethod]
        public void CallDownloadFileOnWebClient()
        {
            var mockWebClient = MockRepository.GenerateMock<IWebClient>();
            mockWebClient.Expect(a => a.DownloadFile(Arg<string>.Is.Equal("http"), Arg<string>.Is.Equal(@"c:\")));
            WebClientImageDownloader downloader = new WebClientImageDownloader(mockWebClient);

            downloader.Download(@"c:\","http");

            mockWebClient.VerifyAllExpectations();
        }
    }
}
