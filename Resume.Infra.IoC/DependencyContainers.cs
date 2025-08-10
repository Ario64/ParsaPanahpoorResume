using Microsoft.Extensions.DependencyInjection;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;

namespace Resume.Infra.IoC
{
    public class DependencyContainers
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IThingIDoService, ThingIDoService>();
            service.AddScoped<ICustomerFeedbackService, CustomerFeedbackService>();
            service.AddScoped<ICustomerLogoService, CustomerLogoService>();
            service.AddScoped<IEducationService, EducationService>();
            service.AddScoped<IExperienceService, ExperienceService>();
            service.AddScoped<ISkillService, SkillService>();
            service.AddScoped<IPortfolioService, PortfolioService>();
            service.AddScoped<ISocialMediaService, SocialMediaService>();
            service.AddScoped<IInformationService, InformationService>();
            service.AddScoped<IMessageService, MessageService>();
        }
    }
}
