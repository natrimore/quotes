using AutoMapper;
using Quote.ViewModels;
using Quotes.API.Queries;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using Quotes.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class GetQuotesByCategoryHandler : IQueryHandler<GetQuotesByCategory, PagedResult<QuoteViewModel>>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public GetQuotesByCategoryHandler(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PagedResult<QuoteViewModel>> HandleAsync(GetQuotesByCategory query)
        {
            if (string.IsNullOrWhiteSpace(query.Category))
            {
                throw new Exception("undefined category");
            }

            var entities = await _quoteRepository.FindByCategoryAsync(query.Category);
            var models = _mapper.Map<List<QuoteViewModel>>(entities);

            return new PagedResult<QuoteViewModel> { Data = models, Total = models.Count };
        }
    }
}
