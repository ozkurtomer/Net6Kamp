using Persistence.Contexts;
using Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Services.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("RentACarCampConnectionString")));

            services.AddScoped<IBrandRepository, BrandRepository>();

            return services;
        }
    }
}
