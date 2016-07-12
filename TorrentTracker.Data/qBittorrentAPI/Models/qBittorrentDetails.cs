namespace TorrentTracker.Data.qBittorrentAPI.Models
{
    public class qBittorrentDetails
    {
        public string Save_path { get; set; }
        public int Creation_date { get; set; }
        public int Piece_size { get; set; }
        public string Comment { get; set; }
        public int Total_wasted { get; set; }
        public long Total_uploaded { get; set; }
        public long Total_uploaded_session { get; set; }
        public long Total_downloaded { get; set; }
        public long Total_downloaded_session { get; set; }
        public int Up_limit { get; set; }
        public int Dl_limit { get; set; }
        public int Time_elapsed { get; set; }
        public long Seeding_time { get; set; }
        public int Nb_connections { get; set; }
        public int Nb_connection_limit { get; set; }
        public float Share_ratio { get; set; }
        public int Addition_date { get; set; }
        public string Completion_date { get; set; }
        public string Created_by { get; set; }
        public int Dl_speed_avg { get; set; }
        public int Dl_speed { get; set; }
        public int Eta { get; set; }
        public int Last_seen { get; set; }
        public int Peers { get; set; }
        public int Peers_total { get; set; }
        public int Pieces_have { get; set; }
        public int Pieces_num { get; set; }
        public int Reannounce { get; set; }
        public int Seeds { get; set; }
        public int Seeds_total { get; set; }
        public int Total_size { get; set; }
        public int Up_speed_avg { get; set; }
        public int Up_speed { get; set; }
    }
}
