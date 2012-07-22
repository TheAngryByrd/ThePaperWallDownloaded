using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core
{
    public class AsyncDownloadManager
    {
        private IImageDownloader _imageDownloader { get; set; }
        public AsyncDownloadManager(IImageDownloader imageDownloader)
        {
            _imageDownloader = imageDownloader;
        }

        public Task GenerateDownloadTasks(string directory, PWImage image)
        {

            return Task.Factory.StartNew(() => _imageDownloader.Download(directory +"\\" + image.imageName, image.imageUrl));
        }

        public void RunTasks(Task[] tasks)
        {
            Task.WaitAll(tasks);
        }
    }
}
