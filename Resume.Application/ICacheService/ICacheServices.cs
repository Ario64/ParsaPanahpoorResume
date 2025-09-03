using System;
using System.Threading.Tasks;

namespace Resume.Application.ICacheService;

public interface ICacheServices
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);
    Task RemoveAsync(string key);
    Task<bool> ExistsAsync(string key);
}
