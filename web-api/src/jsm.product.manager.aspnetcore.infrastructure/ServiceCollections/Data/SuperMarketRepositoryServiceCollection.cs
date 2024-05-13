using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using jsm.product.manager.data.Configuration;
using jsm.product.manager.data.Context;
using jsm.product.manager.data.Repositories;
using jsm.product.manager.domain.Interfaces.Repositories;

namespace jsm.product.manager.aspnetcore.infrastructure.ServiceCollections.Data
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
