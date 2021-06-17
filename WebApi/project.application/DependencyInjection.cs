using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using project.application.Common.Interfaces;
using project.application.Handlers.Produtos;
using project.repository;
using Microsoft.Extensions.Configuration;
using project.application.Common.Mappers;
using project.application.Handlers.Usuarios;

namespace project.application
{
    /// <summary>
    /// Injetor de dependências da camada de aplicação
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Injeta interfaces da camanda de aplicação.
        /// Carregar injetor da camada de infraestrutura
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Service Collection</returns>
        /// 
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureMappers();

            // Infra e Repositorios
            services.AddRepository(configuration);

            // Handlers de commands e querys da camada de aplicação
            services.AddScoped<IProdutoCommandHandler, ProdutoCommandHandler>();
            services.AddScoped<IProdutoQueryHandler, ProdutoQueryHandler>();
            services.AddScoped<IUsuarioCommandHandler, UsuarioCommandHander>();

            return services;
        }
        /// <summary>
        /// Injeta configurações de mapeamento de objetos.
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        private static IServiceCollection ConfigureMappers(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }

}
