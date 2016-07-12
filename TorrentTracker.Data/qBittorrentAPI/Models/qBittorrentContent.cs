namespace TorrentTracker.Data.qBittorrentAPI.Models
{
    public class qBittorrentContent
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public float Progress { get; set; }
        public int Priority { get; set; }
        public bool Is_seed { get; set; }
    }
}
