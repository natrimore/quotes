using Microsoft.Extensions.DependencyInjection;
using Quotes.Shared.Handlers;
using System;
using System.Threading.Tasks;

namespace Quotes.Shared.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task SendAsync<T>(T command) where T : ICommand
        {
            var handler = _serviceProvider.GetService<ICommandHandler<ICommand>>();
            await handler.HandleAsync(command);
        }
    }
}
