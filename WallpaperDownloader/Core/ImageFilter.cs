using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core
{
    public class ImageFilter
    {
        public List<PWImage> RemovePreviouslyDownloadedImages(List<PWImage> images, IEnumerable<FileInfo> fileInfoList)
        {
            List<PWImage> filteredList = new List<PWImage>();
            var downloadedFileNames = fileInfoList.Select(a => a.Name);
            foreach (var image in images)
            {
                if(!downloadedFileNames.Contains(image.imageName))
                {
                    filteredList.Add(image);
                }
            }
            return filteredList;
        }



      
    }
}
