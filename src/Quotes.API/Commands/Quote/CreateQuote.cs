using Quotes.Shared.Dispatchers;
using System;

namespace Quotes.API.Commands
{
    public class CreateQuote : ICommand
    {
        public string QuoteName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }
    }
}
