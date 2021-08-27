using Quotes.Shared.Dispatchers;

namespace Quotes.API.Commands
{
    public class UnsubscribeUser : ICommand
    {
        public string Email { get; set; }
    }
}
