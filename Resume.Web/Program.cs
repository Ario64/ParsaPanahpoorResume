using GoogleReCaptcha.V3.Interface;
using GoogleReCaptcha.V3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Resume.Application.Services.Implementations;
using Resume.Application.Services.Interfaces;
using Resume.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Resume.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();

        #region Add DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        #endregion

        #region ServiceRegistration 

        builder.Services.AddScoped<IThingIDoService, ThingIDoService>();
        builder.Services.AddScoped<ICustomerFeedbackService, CustomerFeedbackService>();
        builder.Services.AddScoped<ICustomerLogoService, CustomerLogoService>();
        builder.Services.AddScoped<IEducationService, EducationService>();
        builder.Services.AddScoped<IExperienceService, ExperienceService>();
        builder.Services.AddScoped<ISkillService, SkillService>();
        builder.Services.AddScoped<IPortfolioService, PortfolioService>();
        builder.Services.AddScoped<ISocialMediaService, SocialMediaService>();
        builder.Services.AddScoped<IInformationService, InformationService>();
        builder.Services.AddScoped<IMessageService, MessageService>();

        #region Google Recaptcha
        builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();
        #endregion

        #endregion

        #region Encoder

        builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

        #endregion

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "area",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();

    }
}