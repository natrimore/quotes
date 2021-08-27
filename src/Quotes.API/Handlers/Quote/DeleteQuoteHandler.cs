using Quotes.API.Commands;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using System;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class DeleteQuoteHandler : ICommandHandler<DeleteQuote>
    {
        private readonly IQuoteRepository _quoteRepository;

        public DeleteQuoteHandler(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));
        }
        public async Task HandleAsync(DeleteQuote command)
        {
            if (command.Id != Guid.Empty) 
            {
                await _quoteRepository.RemoveAsync(command.Id);  
            }
        }
    }
}
