using Microsoft.Extensions.DependencyInjection;
using Resume.Application.ICacheService;
using Resume.Application.UnitOfWork;
using Resume.Domain.IRepository.CustomerFeedback;
using Resume.Domain.IRepository.GenericRepository;
using Resume.Infra.Data.CacheService;
using Resume.Infra.Data.Repository;
using Resume.Infra.Data.UnitOfWork;

namespace Resume.Infra.Data
{
    public static  class InfrastructureServiceRegistration
    {
        public static void ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddSingleton<ICacheServices, CacheServices>();
        }
    }
}
