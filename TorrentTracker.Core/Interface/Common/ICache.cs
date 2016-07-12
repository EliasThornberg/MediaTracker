using System;

namespace TorrentTracker.Core.Interface.Cache
{
    public interface ICache
    {
        T GetValue<T>(string key);

        void SetValue<T>(T value, string key, DateTimeOffset expirationTimeInMinutes);
    }
}
