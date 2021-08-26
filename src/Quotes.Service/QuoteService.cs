using Quotes.Infrastructure.Repository;
using System;

namespace Quotes.Service
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));
        }
    }
}
