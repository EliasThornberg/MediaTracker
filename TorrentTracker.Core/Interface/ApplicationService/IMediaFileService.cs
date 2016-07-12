using System.Collections.Generic;

namespace TorrentTracker.Core.Interface.ApplicationService
{
    public interface IMediaFileService
    {
        List<string> GetMediaFiles(string[] foldersToScan);
    }
}
