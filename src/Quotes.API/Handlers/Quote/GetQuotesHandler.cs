using AutoMapper;
using Quote.ViewModels;
using Quotes.API.Queries;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using Quotes.Shared.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class GetQuotesHandler : IQueryHandler<GetQuotes, PagedResult<QuoteViewModel>>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public GetQuotesHandler(IQuoteRepository quoteRepository, IMapper mapper, IServiceProvider serviceProvider)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

            _serviceProvider = serviceProvider;
        }
        public async Task<PagedResult<QuoteViewModel>> HandleAsync(GetQuotes query)
        {
            var entities = _quoteRepository.FindAllAsync();

            var models = _mapper.Map<List<QuoteViewModel>>(entities);

            return new PagedResult<QuoteViewModel> { Data = models, Total = models.Count };
        }
    }
}
