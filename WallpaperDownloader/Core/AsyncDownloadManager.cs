using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Models;
using Infrastructure;

namespace Core{

    public class AsyncDownloadManager : IAsyncDownloadManager
    {



        public async Task DownloadImages(string mainWallpaperDir, List<PWImage> imageList, Action<PWImage, string> SetupProgress, TaskScheduler scheduler)
        {
            var downloads = new List<Task>();

            SemaphoreSlim semaphore = new SemaphoreSlim(15);
            foreach (var image in imageList)
            {
                await semaphore.WaitAsync();
                var localImage = image;
                var path = Path.Combine(mainWallpaperDir, localImage.Theme.Name, localImage.imageName);
                

                downloads.Add(DownloadImage(image, path, SetupProgress, () => semaphore.Release(), scheduler));

            }
            if(downloads.Any())
                await Task.WhenAll(downloads);
        }

        public async Task DownloadImage(PWImage image, string path, Action<PWImage, string> SetupProgress, Action endTask, TaskScheduler scheduler)
        {
            await Task.Factory.StartNew(() =>
            {
                SetupProgress(image, path);
            }, CancellationToken.None, TaskCreationOptions.None, scheduler);

            using (WebClient wc = new WebClient())
            {

                await wc.DownloadFileTaskAsync(image.imageUrl, path, image.progress);

            }
            endTask();
        }
    }
}
