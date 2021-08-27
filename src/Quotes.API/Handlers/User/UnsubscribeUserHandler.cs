using Quotes.API.Commands;
using Quotes.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Handlers.User
{
    public class UnsubscribeUserHandler : ICommandHandler<UnsubscribeUser>
    {
        public async Task HandleAsync(UnsubscribeUser command)
        {
            
        }
    }
}
