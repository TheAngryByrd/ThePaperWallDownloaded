using System;
using Infrastructure.Models;
namespace Infrastructure
{
    public interface IAsyncDownloadManager
    {
        System.Threading.Tasks.Task DownloadImages(string wallpaperPath, System.Collections.Generic.List<Infrastructure.Models.PWImage> imageList);

        System.Threading.Tasks.Task DownloadImages(string p, System.Collections.Generic.List<Models.PWImage> imageList, Action<PWImage> SetupProgress);


    }
}
