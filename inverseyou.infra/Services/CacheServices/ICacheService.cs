namespace inverseyou.infra.Services.CacheServices
{
    public interface ICacheService
    {
        T Get<T>(string key);
        bool TryGetValue<T>(string key, out T value);
        T Set<T>(string key, T value);
        void Remove<T>(string key);
    }
}
