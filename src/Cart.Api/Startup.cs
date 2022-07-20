using System;
using System.IO;

using Cart.Api.Extensions;
using Cart.Api.Middlewares;
using Cart.Application.Extensions;

using CorrelationId;
using CorrelationId.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;

namespace Cart.Api
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
            services.AddHttpContextAccessor();
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("cart-v1", new OpenApiInfo { Title = "Cart.Api v1", Version = "v1" });
                c.SwaggerDoc("cart-v2", new OpenApiInfo { Title = "Cart.Api v2", Version = "v2" });
                c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml"));
            });

            services.AddPresenters();
            services.AddUseCases();

            services.AddCorrelationId();
            services.AddDefaultCorrelationId(opt =>
            {
                opt.CorrelationIdGenerator = () => Guid.NewGuid().ToString();
                opt.AddToLoggingScope = true;
                opt.IncludeInResponse = true;
                opt.LoggingScopeKey = "Correlation_Id";
                opt.RequestHeader = "Correlation_Id";
                opt.ResponseHeader = "Correlation_Id";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/cart-v1/swagger.json", "Cart.Api v1");
                    c.SwaggerEndpoint("/swagger/cart-v2/swagger.json", "Cart.Api v2");
                });

                app.UseCors(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyOrigin();
                    c.AllowAnyMethod();
                });
            }

            app.UseCorrelationId();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
