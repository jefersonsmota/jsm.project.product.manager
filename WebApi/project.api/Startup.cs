using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using project.api.Filters;
using project.application;
using project.application.Common.Models;
using project.domain.Constants;
using project.domain.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace project.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;

            ConfigureIoC(services);

            services.AddCors();

            services.AddMvc(options =>
            {
                options.Filters.Add(new ApiExceptionFilterAttribute());
            });


            services.AddControllers()
                .AddJsonOptions(opts => { opts.JsonSerializerOptions.IgnoreNullValues = true; })
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        IEnumerable<Notification> errors = null;

                        if (context.ModelState.Any())
                            errors = context.ModelState.Select(x => new Notification(x.Key, x.Value.Errors.First().ErrorMessage));

                        return new BadRequestObjectResult(new CommandResponse(400, Messages.INVALID_FIELDS, null, false) { Notifications = errors });
                    };
                });
        }

        private void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<NotificationContext>();
            services.AddSingleton(Configuration);
            services.AddApplication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
