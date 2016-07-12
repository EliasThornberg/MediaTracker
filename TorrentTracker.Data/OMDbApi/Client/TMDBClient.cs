using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace TorrentTracker.Data.OMDbApi.Client
{
    public class TMDBClient : ITMDBClient
    {
        private string _apiKey;

        public TMDBClient(string apikey)
        {
            _apiKey = apikey;
        }

        public async Task<T> Get<T>(NameValueCollection parameters, string endpoint, bool includedBaseAdress = false)
        {
            var client = new HttpClient();
            if(!includedBaseAdress)
                client.BaseAddress = new Uri("https://api.themoviedb.org/3/");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            if (parameters != null)
                queryString.Add(parameters);

            queryString.Add("api_key", _apiKey);

            var response = await client.GetAsync(endpoint + "?" + queryString.ToString()).ConfigureAwait(false);

            T result = default(T);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }

        public async Task<byte[]> GetFile(NameValueCollection parameters, string endpoint, bool includedBaseAdress = false)
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("api_key", _apiKey);

            var response = await client.GetAsync(endpoint + "?" + queryString.ToString()).ConfigureAwait(false);

            byte[] result = null;
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsByteArrayAsync();
            }

            return result;
        }
    }
}
