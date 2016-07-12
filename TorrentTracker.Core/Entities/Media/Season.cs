using System;
using System.Collections.Generic;
using TorrentTracker.Core.Entities.Common;

namespace TorrentTracker.Core.Entities.Media
{
    public class Season : Entity
    {
        public Season(string title, DateTime releasedate)
        {
            Title = title;
            ReleaseDate = releasedate;

            _Episodes = new List<Episode>();
        }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        private List<Episode> _Episodes;
        public IEnumerable<Episode> Episodes => _Episodes;

        public void AddEpisode(Episode episode)
        {
            _Episodes.Add(episode);
        }
    }
}
