using Quote.ViewModels;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Types;

namespace Quotes.API.Queries
{
    public class GetQuotes : IQuery<PagedResult<QuoteViewModel>>
    {

    }
}
