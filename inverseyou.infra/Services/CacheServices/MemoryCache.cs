using Microsoft.Extensions.Caching.Memory;

namespace inverseyou.infra.Services.CacheServices
{
    public class MemoryCache : ICacheService
    {
        private IMemoryCache _memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        T ICacheService.Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        bool ICacheService.TryGetValue<T>(string key, out T value)
        {
            return _memoryCache.TryGetValue<T>(key, out value);
        }

        T ICacheService.Set<T>(string key, T value)
        {
            return _memoryCache.Set<T>(key, value);
        }

        void ICacheService.Remove<T>(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
