namespace TorrentTracker.Data.OMDbApi.Models.Search.Show
{
    public class SearchShowResult
    {
        public string Backdrop_path { get; set; }
        public string First_air_date { get; set; }
        public int[] Genre_ids { get; set; }
        public int Id { get; set; }
        public string Original_language { get; set; }
        public string Original_name { get; set; }
        public string Overview { get; set; }
        public string [] Origin_country { get; set; }
        public string Poster_path { get; set; }
        public float Popularity { get; set; }
        public string Name { get; set; }
        public float Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
