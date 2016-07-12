using System;
using System.Runtime.Caching;
using TorrentTracker.Core.Interface.Cache;

namespace TorrentTracker.Data
{
    public class Cache : ICache
    {
        public T GetValue<T>(string key)
        {
            return (T)MemoryCache.Default.Get(key);
        }

        public void SetValue<T>(T value, string key, DateTimeOffset expirationTimeInMinutes)
        {
            MemoryCache.Default.Add(key, value, expirationTimeInMinutes);
        }
    }
}
