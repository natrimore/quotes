using AutoMapper;
using Quote.ViewModels;
using Quotes.API.Queries;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using System;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class GetRandomQuoteHandler : IQueryHandler<GetRandomQuote, QuoteViewModel>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public GetRandomQuoteHandler(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<QuoteViewModel> HandleAsync(GetRandomQuote query)
        {
            var entities = await _quoteRepository.FindAllAsync();

            var model = _mapper.Map<QuoteViewModel>(entities);

            return model;
        }
    }
}
