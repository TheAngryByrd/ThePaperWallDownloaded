using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class AsyncDownloadManager
    {
        private IImageDownloader _imageDownloader { get; set; }
        public AsyncDownloadManager(IImageDownloader imageDownloader)
        {
            _imageDownloader = imageDownloader;
        }

        public List<Task> GenerateDownloadTasks(string directory, List<PWImage> images)
        {
            List<Task> tasks = images.Select(image => Task.Factory.StartNew(() => _imageDownloader.Download(directory +"\\" + image.imageName, image.imageUrl))).ToList();

            return tasks;
        }

        public void RunTasks(Task[] tasks)
        {
            Task.WaitAll(tasks);
        }
    }
}
