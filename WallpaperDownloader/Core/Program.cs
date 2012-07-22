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
        
        public async Task Run(string themeName, string feedUrl)
        {
             string themeDirectory = @"c:\wallpapers\" + themeName;
            var rssReader = new RssReader();
            var feed = rssReader.GetFeed(feedUrl);
            var parser = new PaperWallRssParser();
            var pwImages = parser.GetImageUrls(feed);

            var imageFilter = new ImageFilter();

            var dir = Directory.CreateDirectory(themeDirectory);

            

            pwImages = imageFilter.RemovePreviouslyDownloadedImages(pwImages, dir.EnumerateFiles());
            List<Task> taks = new List<Task>();
            foreach (var image in pwImages)
            {
                var webClient = new WebClientWrapper();
                var imageDownloader = new WebClientImageDownloader(webClient);
                var manager = new AsyncDownloadManager(imageDownloader);

                var tasks = manager.GenerateDownloadTasks(themeDirectory, image);
                taks.Add(tasks);
            }
            await Task.WhenAll(taks);
            
        }
    }
}
