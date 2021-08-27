using Quotes.Shared.Dispatchers;

namespace Quotes.API.Commands
{
    public class SubscribeUser : ICommand
    {
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
    }
}
