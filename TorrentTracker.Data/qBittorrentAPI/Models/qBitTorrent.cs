namespace TorrentTracker.Data.qBittorrentAPI.Models
{
    public class qBittorrent
    {
        public string Hash { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public float Progress { get; set; }
        public int Dlspeed { get; set; }
        public int Upspeed { get; set; }
        public int Priority { get; set; }
        public int Num_seeds { get; set; }
        public int Num_leechs { get; set; }
        public int Num_incomplete { get; set; }
        public float Ratio { get; set; }
        public int Eta { get; set; }
        public string State { get; set; }
        public bool Seq_dl { get; set; }
        public bool F_l_piece_prio { get; set; }
        public string Label { get; set; }
        public bool Super_seeding { get; set; }
        public bool Force_start { get; set; }
    }
}
