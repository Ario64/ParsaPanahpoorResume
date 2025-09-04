using AngleSharp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.CacheService;
using Resume.Infra.Data.Repository;
using StackExchange.Redis;

namespace Resume.Infra.Data
{
    public static class InfrastructureServiceRegistration
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            services.AddSingleton<IConnectionMultiplexer>(sp =>
            {
                var redisConnection = configuration.GetConnectionString("RedisConnection");
                return ConnectionMultiplexer.Connect(redisConnection);
            });
            services.AddSingleton<ICacheServices, CacheServices>();
        }
    }
}
