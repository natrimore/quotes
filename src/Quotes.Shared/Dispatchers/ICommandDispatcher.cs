using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quotes.Shared.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}
