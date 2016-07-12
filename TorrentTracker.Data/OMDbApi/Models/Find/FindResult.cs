using System.Collections.Generic;

namespace TorrentTracker.Data.OMDbApi.Models.Find
{
    public class FindResult
    {
        public List<FindShow> Tv_results { get; set; }

        public List<FindEpisode> Tv_episode_results { get; set; }
    }
}
