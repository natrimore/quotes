using AutoMapper;
using Quotes.API.Commands;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Handlers
{
    public class CreateQuoteHandler : ICommandHandler<CreateQuote>
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public CreateQuoteHandler(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository ??
                throw new ArgumentNullException(nameof(quoteRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task HandleAsync(CreateQuote command)
        {
            var entity = new Domain.Quote() { Author = command.Author, Category = command.Category, QuoteName = command.QuoteName };
            await _quoteRepository.CreateAsync(entity);
        }
    }
}
