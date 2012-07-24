using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Models;
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
            var feed =  reader.GetFeed("http://www.thepaperwall.com/category_rss.php?feed=people").Result;
            Assert.AreEqual("ThePaperWall.com", feed.channel.title);
        }

        private string expectedImageUrl = @"http://thepaperwall.com/wallpapers/people/big/big_584778739bace9b64fb91975340190ed2f64a51d.jpg";
        [TestMethod]
        public void CanGetImagesFromRssFeed()
        {

            string description = string.Format(@"<p><a href=""{0}""><img src=""http://thepaperwall.com/wallpapers/people/small/small_584778739bace9b64fb91975340190ed2f64a51d.jpg?x=130&y=89&q=85&sig=SVA2qhNVOsYltxwW7ULPyQ--"" align=""left"" height=""150"" width=""240""/>", expectedImageUrl);
            var rssChannelItem = new rssChannelItem
            {
                description =
                    description
            };
            var rssChannelItem2 = new rssChannelItem
            {
                description =
                    description
            };

            RssReader reader = new RssReader();


            var rss = new rss
            {
                channel = new rssChannel
                {
                    item = new rssChannelItem[] { rssChannelItem, rssChannelItem2 }
                }
            };
            List<PWImage> imageUrls = reader.GetImageUrls(rss);

            Assert.AreEqual(2, imageUrls.Count);

            foreach (var image in imageUrls)
            {
                Assert.AreEqual(expectedImageUrl, image.imageUrl);
            }
        }
    }
}
