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
        public async Task DownloadImages(string wallpaperPath, List<PWImage> imageList)
        {
            DownloadImages(wallpaperPath, imageList, null);
        }


        public async Task DownloadImages(string p, List<PWImage> imageList, Action<PWImage> SetupProgress)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(10, 15);
            var downloads = new List<Task>();
            foreach (var image in imageList)
            {
                await semaphore.WaitAsync();

                var task = Task.Factory.StartNew(async () =>
                {
                    try
                    {
                        using (WebClient wc = new WebClient())
                        {
                            if (SetupProgress != null)
                                SetupProgress(image);

                            await wc.DownloadFileTaskAsync(image.imageUrl, Path.Combine(@"c:\wallpapers", image.Theme.Name, image.imageName), image.progress);
                        }
                    }
                    finally
                    {
                        semaphore.Release();
                    }

                });

                downloads.Add(task);

            }

            if (downloads.Any())
                await Task.WhenAll(downloads);
        }
    }
}
