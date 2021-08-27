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
        public Task HandleAsync(UpdateQuote command)
        {
            throw new NotImplementedException();
        }
    }
}
