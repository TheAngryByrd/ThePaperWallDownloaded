using System;
namespace Infrastructure
{
    public interface IImageFilter
    {
        System.Collections.Generic.List<Infrastructure.Models.PWImage> RemovePreviouslyDownloadedImages(System.Collections.Generic.List<Infrastructure.Models.PWImage> images, System.Collections.Generic.IEnumerable<System.IO.FileInfo> fileInfoList);
    }
}
