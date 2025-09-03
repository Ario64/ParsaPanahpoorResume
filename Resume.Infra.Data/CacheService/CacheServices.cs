using Resume.Application.ICacheService;
using Resume.Infra.Data.Migrations;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Resume.Infra.Data.CacheService;

public class CacheServices : ICacheServices
{
    #region Constructor

    private readonly IConnectionMultiplexer _redis;

    public CacheServices(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }

    #endregion

    public Task<bool> ExistsAsync(string key)
    {
        var db = _redis.GetDatabase();
        return db.KeyExistsAsync(key);
    }

    public async Task<T> GetAsync<T>(string key)
    {
        var db = _redis.GetDatabase();
        var value = await db.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;
        return JsonSerializer.Deserialize<T>(value);

    }

    public async Task RemoveAsync(string key)
    {
        var db = _redis.GetDatabase();
        await db.KeyDeleteAsync(key);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
    {
        var db = _redis.GetDatabase();
        var json = JsonSerializer.Serialize(value);
        await db.StringSetAsync(key, json, expiry);

    }
}
