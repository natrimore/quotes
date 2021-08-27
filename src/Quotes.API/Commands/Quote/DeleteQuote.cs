using Quotes.Shared.Dispatchers;
using System;

namespace Quotes.API.Commands
{
    public class DeleteQuote : ICommand
    {
        public Guid Id { get; set; }
    }
}
