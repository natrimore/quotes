using Quotes.Shared.Dispatchers;

namespace Quotes.API.Commands
{
    public class DeleteQuote : ICommand
    {
        public int Id { get; set; }
    }
}
