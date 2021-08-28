using Quotes.Shared.Dispatchers;
using System;

namespace Quotes.API.Commands
{
    public class UpdateQuote : ICommand
    {
        public Guid Id { get; set; }
        public string QuoteName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public DateTime Created { get; set; }

    }
}
