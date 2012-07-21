using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.IntegrationTests
{
    [TestClass]
    public class RssReaderShould
    {
        [TestMethod]
        public void DownloadRssFeed()
        {
            var reader = new RssReader();
            var feed = reader.GetFeed("http://www.thepaperwall.com/category_rss.php?feed=people");
            Assert.AreEqual("ThePaperWall.com", feed.channel.title);
        }
    }
}
