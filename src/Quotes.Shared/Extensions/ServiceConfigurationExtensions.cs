using Microsoft.Extensions.DependencyInjection;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Handlers;
using System.Linq;
using System.Reflection;

namespace Quotes.Shared.Extensions
{
    public static class ServiceConfigurationExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            var assembly = Assembly.GetEntryAssembly();

            var types = assembly.GetTypes()
                .Where(s => !s.IsAbstract && !s.IsInterface &&
                    s.GetInterfaces().Any(v =>
                        v.IsGenericType && (v.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                        v.GetGenericTypeDefinition() == typeof(IQueryHandler<,>))));

            foreach (var type in types)
            {
                var genericType = type.GetInterfaces().FirstOrDefault();
                services.AddScoped(genericType, type);
            }


            return services;
        }

        public static IServiceCollection AddDispatchers(this IServiceCollection services)
        {
            services.AddScoped<IDispatcher, Dispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();

            return services;
        }
    }
}
