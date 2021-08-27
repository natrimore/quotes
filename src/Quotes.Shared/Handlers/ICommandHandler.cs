using Quotes.Shared.Dispatchers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Shared.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
