using System.IO;
using System.Collections.Generic;
using TorrentTracker.Core.Interface.ApplicationService;

namespace TorrentTracker.Data.FileService
{
    public class MediaFileService : IMediaFileService
    {
        public List<string> GetMediaFiles(string[] foldersToScan)
        {
            List<string> files = new List<string>();
            foreach(var folder in foldersToScan)
            {
                files.AddRange(Directory.EnumerateFiles(folder, "*", SearchOption.AllDirectories));
            }

            return files;
        }
    }
}
