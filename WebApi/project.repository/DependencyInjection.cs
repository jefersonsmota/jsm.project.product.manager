using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using project.repository.Context;
using project.repository.Interfaces;
using project.repository.Repositories;
using System.Net.Http;

namespace project.repository
{
    /// <summary>
    /// Injetor de dependencias do repositorio 
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectDBContext>(opt =>
                {
                    var connStr = configuration.GetConnectionString("DefaultConnection");
                    opt.UseSqlServer(connStr, b => b.MigrationsAssembly(typeof(ProjectDBContext).Assembly.FullName));
                }
            );
            services.AddScoped<HttpClient>();
            services.AddScoped<ProjectDBContext, ProjectDBContext>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}
