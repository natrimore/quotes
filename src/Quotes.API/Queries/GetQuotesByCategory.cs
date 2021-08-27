using Quote.ViewModels;
using Quotes.Shared.Dispatchers;
using Quotes.Shared.Types;
using System.ComponentModel.DataAnnotations;

namespace Quotes.API.Queries
{
    public class GetQuotesByCategory : IQuery<PagedResult<QuoteViewModel>>
    {
        [Required]
        public string Category { get; set; }
    }


}
