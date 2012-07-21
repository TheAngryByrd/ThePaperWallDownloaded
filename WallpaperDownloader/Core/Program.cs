using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Program
    {
        public void Run(string themeName, string feedUrl)
        {
            var rssReader = new RssReader();
            var feed = rssReader.GetFeed(feedUrl);
            var parser = new PaperWallRssParser();
            var pwImages = parser.GetImageUrls(feed);

            var imageFilter = new ImageFilter();
            var themeDirectory = @"c:\wallpapers\"+ themeName;

            

            pwImages = imageFilter.RemovePreviouslyDownloadedImages(pwImages, new DirectoryInfo(themeDirectory).EnumerateFiles());
            
            var webClient = new WebClientWrapper();
            var imageDownloader = new WebClientImageDownloader(webClient);
            var manager = new AsyncDownloadManager(imageDownloader);

            var tasks = manager.GenerateDownloadTasks(@"c:\wallpapers\"+ themeName , pwImages);
            manager.RunTasks(tasks.ToArray());
        }
    }
}
