using System.Collections.Generic;
using TorrentTracker.Core.Entities.Common;
using TorrentTracker.Core.Sharedkernel;

namespace TorrentTracker.Core.Entities.Media
{
    public class Movie : AggregateRoot
    {
        public Movie(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string PosterImagePath { get; set; }

        public string BorderImagePath { get; set; }

        private List<Genre> _genres;
        public IEnumerable<Genre> Genres => _genres;

        public void AddGenre(Genre genre)
        {
            _genres.Add(genre);
        }
    }
}
