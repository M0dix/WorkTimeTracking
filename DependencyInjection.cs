using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO.Compression;
using System.Runtime.CompilerServices;
using WorkTimeTracking.Middlewares;
using WorkTimeTracking.Persistence;
using WorkTimeTracking.Persistence.Data;
using WorkTimeTracking.Persistence.Interfaces;
using WorkTimeTracking.Persistence.Repositories;


namespace WorkTimeTracking
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("postgres")));
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
            });
            services.AddControllers();
            services.AddMemoryCache();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<GlobalExceptionHandlerMiddleware>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWorkReportRepository, WorkReportRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            return services;
        }
    }
}
