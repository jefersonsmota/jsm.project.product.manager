using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using project.data.Configuration;
using project.data.Context;
using project.data.Repositories;
using project.domain.Interfaces.Repositories;

namespace project.aspnetcore.infrastructure.ServiceCollections.Data
{
    public static class SuperMarketRepositoryServiceCollection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<HttpClient>();
            services.AddSingleton<IProductEntityFrameworkMapping, ProductEntityFrameworkMapping>();

            services.AddDbContext<ProjectDBContext>(opt =>
            {
                var connStr = configuration.GetConnectionString("SuperMarketConnection");
                opt.UseSqlServer(connStr, b => b.MigrationsAssembly(typeof(ProjectDBContext).Assembly.FullName));
            }
            );

            services.AddScoped<IProjectDBContext>(x => x.GetRequiredService<ProjectDBContext>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
