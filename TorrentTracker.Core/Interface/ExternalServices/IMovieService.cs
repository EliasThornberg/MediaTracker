using System.Collections.Generic;
using System.Threading.Tasks;
using TorrentTracker.Core.Entities.Media;

namespace TorrentTracker.Core.Interface.ExternalServices
{
    public interface IMovieService
    {
        Task<Movie> GetMovieById(string imdbId);

        Task<Show> GetShowById(string imdbId);

        Task<Episode> GetEpisodeById(string imdbId);

        Task<IEnumerable<Movie>> SearchMovie(string searchText, bool fullPlot);

        Task<IEnumerable<Show>> SearchShow(string searchText, bool fullPlot);

        Task<IEnumerable<Episode>> SearchEpisode(string searchText, bool fullPlot);

        Task<byte[]> GetPoster(string path);
    }
}
