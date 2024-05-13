using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

namespace jsm.product.manager.aspnetcore.infrastructure.ServiceCollections.Infrastructure
{
    public static class ElasticsearchLogServiceCollection
    {
        public static IServiceCollection AddService(this IServiceCollection services, ConfigureHostBuilder host)
        {
            var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            logger.Debug("init main");
            try
            {
                services.AddLogging(logging =>
                {
                    logging.ClearProviders();
                });
                host.UseNLog();
            }
            catch (Exception ex)
            {
                // NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }

            return services;
        }
    }
}
