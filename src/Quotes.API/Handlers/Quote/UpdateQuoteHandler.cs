using AutoMapper;
using Quotes.API.Commands;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using System;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class UpdateQuoteHandler : ICommandHandler<UpdateQuote>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public UpdateQuoteHandler(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task HandleAsync(UpdateQuote command)
        {
            var quote = _mapper.Map<Domain.Quote>(command);

            _quoteRepository.UpdateAsync(quote);
        }
    }
}
