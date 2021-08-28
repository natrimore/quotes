using Quote.ViewModels;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Types;

namespace Quotes.API.Queries
{
    public class GetUsers: IQuery<PagedResult<UserViewModel>>
    {
    }
}
