using System.Collections.Generic;
using TorrentTracker.Core.Entities.Common;
using TorrentTracker.Core.Sharedkernel;

namespace TorrentTracker.Core.Entities.Media
{
    public class Show : AggregateRoot
    {
        public Show(string title, string description)
        {
            Title = title;
            Description = description;

            _seasons = new List<Season>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PosterImagePath { get; set; }

        public string BorderImagePath { get; set; }

        private List<Season> _seasons;
        public IEnumerable<Season> Seasons => _seasons;
        public void AddSeason(Season season)
        {
            _seasons.Add(season);
        }

        private List<Genre> _genres;
        public IEnumerable<Genre> Genres => _genres;

        public void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }
    }
}
