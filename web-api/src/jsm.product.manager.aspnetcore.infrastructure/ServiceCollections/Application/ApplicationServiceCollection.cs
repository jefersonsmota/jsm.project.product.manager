using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using jsm.product.manager.application.Handlers.Products;
using jsm.product.manager.application.Mappings.Products;

namespace jsm.product.manager.aspnetcore.infrastructure.ServiceCollections.Application
{
    public static class ApplicationServiceCollection
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

            // Handlers de commands e querys da camada de aplicação
            services.AddScoped<IUpdateProduct, UpdateProduct>();
            services.AddScoped<IGetProduct, GetProduct>();
            services.AddScoped<IGetAllProducts, GetAllProducts>();
            services.AddScoped<IDeleteProduct, DeleteProduct>();
            services.AddScoped<ICreateProduct, CreateProduct>();

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
                cfg.AddProfile<PostProductMappingProfile>();
                cfg.AddProfile<GetProductResponseMappingProfile>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
