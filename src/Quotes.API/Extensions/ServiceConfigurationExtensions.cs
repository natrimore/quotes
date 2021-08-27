using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Quotes.API.Helpers;
using Quotes.Infrastructure;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Messaging;

namespace Quotes.API.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            //services.AddDbContext<QuoteContext>(options =>
            //    options.UseInMemoryDatabase());

            services.AddSingleton<QuoteContext>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<BackgroundJobInitializer>()
                .AddScoped<IEmailService, EmailService>()
                .AddScoped<IQuoteRepository, QuoteRepository>()
                .AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(action =>
            {
                //action.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setupAction =>
            {
                setupAction.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                setupAction.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            }).AddXmlDataContractSerializerFormatters()
              .ConfigureApiBehaviorOptions(options =>
              {
                  options.InvalidModelStateResponseFactory = context =>
                  {
                      var problemDetails = new ValidationProblemDetails(context.ModelState)
                      {
                          Type = "http://api.ipay.uz/",
                          Title = "One or more model validation errors occured.",
                          Status = StatusCodes.Status422UnprocessableEntity,
                          Detail = "See the errors property for details.",
                          Instance = context.HttpContext.Request.Path
                      };

                      problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

                      return new UnprocessableEntityObjectResult(problemDetails)
                      {
                          ContentTypes = { "application/problem+json" }
                      };

                  };
              });
            return services;
        }

        public static IServiceCollection AddCustomHangfire(this IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                    .UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore })
                   .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                   .UseSimpleAssemblyNameTypeSerializer()
                   .UseRecommendedSerializerSettings()
                   .UseMemoryStorage());

            return services;
        }
    }
}
