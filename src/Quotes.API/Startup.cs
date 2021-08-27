using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quotes.API.Extensions;
using Quotes.API.Helpers;
using Quotes.Shared.Extensions;
using Quotes.Shared.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Quotes.API
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
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            services
                .AddCustomMvc()
                .AddSingleton(Configuration)
                .AddCustomDbContext()
                .AddServices()
                .AddHandlers()
                .AddDispatchers()
                .AddCustomHangfire()
                .AddSwaggerDocs(xmlPath);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddCors();
            //var container = new ContainerBuilder();

            //container.Populate(services);

            //ILifetimeScope lifetimeScope = container.Build();

            //return new AutofacServiceProvider(lifetimeScope);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BackgroundJobInitializer backgroundJobInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(c => c
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseSwaggerDocs();

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseExceptionHandler(hanlder =>
            {
                hanlder.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("Ooops! An unexpected fault happened. Try again later.");
                });
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            backgroundJobInitializer.InitializeJob();
        }
    }
}
