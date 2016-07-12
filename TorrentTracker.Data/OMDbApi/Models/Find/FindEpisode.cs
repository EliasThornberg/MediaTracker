namespace TorrentTracker.Data.OMDbApi.Models.Find
{
    public class FindEpisode
    {
        public string Air_date { get; set; }
        public int Episode_number { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Season_number { get; set; }
        public string Still_path { get; set; }
        public int Show_id { get; set; }
        public float Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
