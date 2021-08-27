using Quotes.Shared.Dispatchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Commands
{
    public class CreateQuote : ICommand
    {
        public string QuoteName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
