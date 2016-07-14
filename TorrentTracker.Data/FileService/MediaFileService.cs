using System.IO;
using System.Collections.Generic;
using TorrentTracker.Core.Interface.ApplicationService;

namespace TorrentTracker.Data.FileService
{
    public class MediaFileService : IMediaFileService<MediaInfo>
    {
        public IEnumerable<MediaInfo> GetMediaFiles(string[] foldersToScan)
        {
            foreach(var folder in foldersToScan)
            {
                var files = Directory.EnumerateFiles(folder, "*.avi", SearchOption.AllDirectories);
                foreach(var file in files)
                {
                    var cleanFilename = FilenameCleaner.Clean(Path.GetFileNameWithoutExtension(file));
                    var mediaInfo = new MediaInfo(cleanFilename);

                    yield return mediaInfo;
                }
            }
        }
    }
}
