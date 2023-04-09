using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyWebApi.Data;
using CompanyWebApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        { });

        public static void ConfigureLoggerService(this IServiceCollection service)
        {
            service.AddSingleton<ILoggerManager, LoggerService>();
        }

        public static void ConfigureMssqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
        }

        //configure repository wrapper here
    }
}