using Quotes.Shared.Dispatchers;

namespace Quotes.API.Commands
{
    public class UpdateQuote : ICommand
    {
        public string QuoteName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
