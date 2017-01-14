using Microsoft.Extensions.Caching.Memory;
using System;

namespace Mess
{
public class MemoryCache : ICache
{
    public MemoryCache(IMemoryCache cache) {
        this.cache = cache;
    }
    IMemoryCache cache;

    public void Set(string key, object value, DateTime expiration) {
        cache.Set(key, value, DateTimeOffset.Now.AddDays(1));
    }

    public object Get(string key) {
        return cache.Get(key);
    }

    public void Remove(string key) {
        cache.Remove(key);
    }
}
}