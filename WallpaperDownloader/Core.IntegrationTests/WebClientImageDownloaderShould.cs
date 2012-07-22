using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using System.Linq;

namespace Core.IntegrationTests
{
    [TestClass]
    public class WebClientImageDownloaderShould
    {
        public string testDir = @"c:\testWallpaperDier" + Guid.NewGuid().ToString();
        DirectoryInfo dirInfo = null;
        [TestInitialize]
        public void Setup()
        {
            dirInfo = Directory.CreateDirectory(testDir);
        }

        [TestCleanup]
        public void Cleanup()
        {
            dirInfo.Delete(true);
        }

        [TestMethod]
        public void ShouldDownloadImageFromUrl()
        {
            var downloader = new WebClientImageDownloader(new WebClientWrapper());

            downloader.Download(testDir + @"\fileName.jpg", @"http://thepaperwall.com/wallpapers/people/big/big_584778739bace9b64fb91975340190ed2f64a51d.jpg");

            var files = dirInfo.EnumerateFiles();

            Assert.AreEqual(1, files.Count());

        }
    }
}
