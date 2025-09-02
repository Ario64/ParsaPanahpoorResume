using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Resume.Application;

public static class ApplicationServiceRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}