using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TorrentTracker.Core.Interface.Cache;

namespace TorrentTracker.Data.qBittorrentAPI.Client
{
    public class qBittorrentClient : IqBittorrentClient
    {
        private readonly ICache _cache;

        public qBittorrentClient(ICache cache)
        {
            _cache = cache;
        }

        public async Task<string> Login(string username, string password)
        {
            CookieContainer cookies = new CookieContainer();
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            handler.UseCookies = true;

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://localhost:8080/");

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });

            var response = await client.PostAsync("login", content).ConfigureAwait(false);

            string result = "";
            if(response.IsSuccessStatusCode)
            {
                var tempCookies = cookies.GetCookies(new Uri("http://localhost:8080/login")).Cast<Cookie>();
                var cookie = tempCookies.FirstOrDefault(x => x.Name == "SID");

                result = cookie?.Value;
                if (!string.IsNullOrEmpty(result))
                    _cache.SetValue(cookie, username, DateTimeOffset.Now.AddMinutes(30));

            }

            return result;
        }

        public void Post<T>(T objects)
        { 
        }

        public async Task<T> Get<T>(string username, string password, NameValueCollection collection, string endpoint)
        {
            var cookieContainer = new CookieContainer();
            var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://192.168.0.19:8080");

            var sid = _cache.GetValue<Cookie>(username);
            if (sid == null)
            {
                await Login(username, password);
                sid = _cache.GetValue<Cookie>(username);
            }
            cookieContainer.Add(client.BaseAddress, sid);

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            if(collection != null)
                queryString.Add(collection);

            var response = await client.GetAsync(endpoint + (queryString.Count > 0 ? "?" + queryString.ToString() : "")).ConfigureAwait(false);

            T result = default(T);
            if(response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<T>();
            }

            return result;
        }
    }
}
