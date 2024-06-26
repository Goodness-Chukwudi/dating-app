using API.Data;
using API.Helpers;
using API.interfaces;
using API.Interfaces;
using API.services;
using API.Services;
using API.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<LogUserActivity>();
            services.AddSingleton<PresenceTracker>();
            services.AddDbContext<DataContext>(options =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlite(connectionString);
            });

            return services;
        }
    }
}