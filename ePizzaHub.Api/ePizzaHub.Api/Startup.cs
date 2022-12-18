using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileServices.FileCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using DataModel.Configurations;
using ePizzaHub.Api.Middlewares;
using ServiceLayer.Services;
using DataAccessLayer.Repositories;

namespace ePizzaHub.Api
{
    public class Startup
    {
        private readonly string CorsPolicyName = "AllowCORS";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors( option =>  option.AddPolicy(CorsPolicyName, builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build()
                            ));

            services.AddOptions<AppConfig>().
               Bind(Configuration.GetSection("AppConfig"));


            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepository>();
            services.AddTransient<ISaucesRepository, SaucesRepository>();
            services.AddTransient<IToppingsRepository, ToppingsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INonPizzaRepository, NonPizzaRepository>();
            services.AddTransient<IPizzaIngredientsRepository, PizzaIngredientsRepository>();
            services.AddTransient<ISizeRepository, SizeRepository>();

            services.AddTransient<ExceptionHandlingMiddleware >();

            services.AddSingleton<JsonSerializerDeserializer>();
            services.AddSingleton<XmlSerializerDeserializer>();

            services.AddSingleton<Func<string, SerializationDeserialization>>(serviceProvider => key =>
                {
                        switch (key)
                        {
                            case "XML":
                                return serviceProvider.GetService<XmlSerializerDeserializer>();
                            case "JSON":
                                return serviceProvider.GetService<JsonSerializerDeserializer>();
                            default:
                                throw new NotImplementedException();
                        }
                });


            services.AddSwaggerGen();
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = "v1",
                        Title = "ePizzaHub.API",
                        Description = "ePizzaHub API",
                    });
                   
                  }
                );
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
                            c.SwaggerEndpoint("/swagger/v1/swagger.json", "ePizzaHub.API v1");
                        }

                    );
            }
            app.UseCors(CorsPolicyName);
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            
            app.UseRouting();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
