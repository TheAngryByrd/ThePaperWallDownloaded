using System;
using Infrastructure.Models;
namespace Infrastructure
{
    public interface IAsyncDownloadManager
    {
        System.Threading.Tasks.Task DownloadImages(string mainWallpaperDir, System.Collections.Generic.List<Infrastructure.Models.PWImage> imageList, Action<Infrastructure.Models.PWImage,string> SetupProgress, System.Threading.Tasks.TaskScheduler ui);
    }
}
