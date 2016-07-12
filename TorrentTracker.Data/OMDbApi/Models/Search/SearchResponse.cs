using System.Collections.Generic;

namespace TorrentTracker.Data.OMDbApi.Models.Search
{
    public class SearchResponse<T>
    {
        public int Page { get; set; }

        public IEnumerable<T> Results { get; set; }

        public int Total_pages { get; set; }

        public int Total_results { get; set; }
    }
}
