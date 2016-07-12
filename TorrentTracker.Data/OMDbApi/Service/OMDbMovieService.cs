using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using TorrentTracker.Core.Entities.Media;
using TorrentTracker.Core.Interface.ExternalServices;
using TorrentTracker.Data.OMDbApi.Client;
using TorrentTracker.Data.OMDbApi.Models.Find;
using TorrentTracker.Data.OMDbApi.Models.Search;
using TorrentTracker.Data.OMDbApi.Models.Search.Show;

namespace TorrentTracker.Data.Service.OMDbApi
{
    public class OMDbMovieService : IMovieService
    {
        private readonly ITMDBClient _client;
        public OMDbMovieService(ITMDBClient client)
        {
            _client = client;
        }

        public Task<Episode> GetEpisodeById(string imdbId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieById(string imdbId)
        {
            throw new NotImplementedException();
        }

        public async Task<byte[]> GetPoster(string path)
        {
            var tmdbResult = await _client.GetFile(null, "http://image.tmdb.org/t/p/original/" + path, true);

            return tmdbResult;
        }

        public async Task<Show> GetShowById(string imdbId)
        {
            var parameters = new NameValueCollection()
            {
                { "external_source", "imdb_id" }
            };

           var tmdbResult =  await _client.Get<FindResult>(parameters, "/3/find/" + imdbId);

            Show show = null;
            var tmdbShow = tmdbResult.Tv_results.FirstOrDefault();
            if (tmdbShow != null)
            {
                show = new Show(tmdbShow.Name, tmdbShow.Overview);
                show.PosterImagePath = tmdbShow.Poster_path;
                show.BorderImagePath = tmdbShow.Backdrop_path;
            }

            return show;
        }

        public Task<IEnumerable<Episode>> SearchEpisode(string searchText, bool fullPlot)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> SearchMovie(string searchText, bool fullPlot)
        {
            var parameters = new NameValueCollection()
            {
                {"query", searchText }
            };

            var tmdbResult = await _client.Get<SearchResponse<SearchMovieResult>>(parameters, "/3/search/movie");

            List<Movie> movies = new List<Movie>();
            foreach(var m in tmdbResult.Results)
            {
                Movie movie = new Movie(m.Title, m.Overview);
                movie.PosterImagePath = m.Poster_path;
                movie.BorderImagePath = m.Backdrop_path;

                movies.Add(movie);
            }

            return movies;
        }

        public async Task<IEnumerable<Show>> SearchShow(string searchText, bool fullPlot)
        {
            var parameters = new NameValueCollection()
            {
                {"query", searchText }
            };

            var tmdbResult = await _client.Get<SearchResponse<SearchShowResult>>(parameters, "/3/search/tv");

            List<Show> shows = new List<Show>();
            foreach (var s in tmdbResult.Results)
            {
                Show show = new Show(s.Name, s.Overview);
                show.PosterImagePath = s.Poster_path;
                show.BorderImagePath = s.Backdrop_path;

                shows.Add(show);
            }

            return shows;
        }
    }
}
