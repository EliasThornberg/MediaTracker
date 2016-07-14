using System.Collections.Generic;

namespace TorrentTracker.Core.Interface.ApplicationService
{
    public interface IMediaFileService<T>
    {
        IEnumerable<T> GetMediaFiles(string[] foldersToScan);
    }
}
