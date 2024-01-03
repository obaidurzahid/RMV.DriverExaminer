using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RMV.DriverExaminer.Infrastructure.Data;
using RMV.DriverExaminer.Service.Services;
using RMV.Infrastructure.Repositories;
using RMV.Infrastructure.Repositories.Base;
using RMV.DriverExaminer.Service.Interfaces.Repositories;
using RMV.DriverExaminer.Service.Interfaces.Repositories.Base;
using RMV.DriverExaminer.Service.Interfaces;
using RMV.DriverExaminer.Infrastructure.Common;
using RMV.DriverExaminer.Infrastructure.Repositories;

namespace RMV.Infrastructure
{
    ////https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-8.0
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddConfigaration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(db =>
            {
                db.UseSqlServer(config.GetConnectionString("RMVDBConnection"));
                //options.UseLoggerFactory(_loggerFactory);
            });

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //Common Services
            
            //services.AddScoped<IEmailSender, EmailSender>();
            //services.AddScoped<IFileStorageService, AzureStorageService>();



            //Repository
            services.AddScoped(typeof(IRepositoryBaseAsync<>), typeof(RepositoryBaseAsync<>));
            services.AddTransient<ISampleRepository, SampleRepository>();
            services.AddTransient<ISampleService, SampleService>();
            services.AddTransient<IExamDetailsRepository, ExamDetailsRepository>();
            services.AddTransient<IExamDetailsService, ExamDetailsService>();
            return services;
        }
    }
}
