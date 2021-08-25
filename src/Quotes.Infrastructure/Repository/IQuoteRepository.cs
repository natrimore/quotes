using Quotes.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Infrastructure.Repository
{
    public interface IQuoteRepository
    {
        Task<List<Quote>> FindAllAsync();

        Task<Quote> FindByIdAsync(int id);

        Task<List<Quote>> FindByAuthorAsync(string author);

        Task<List<Quote>> FindByCategoryAsync(string category);

        Task<bool> RemoveAsync(int id);

        Task<bool> CreateAsync(Quote entity);

        Task<Quote> UpdateAsync(Quote entity);

        Task<bool> SaveChangesAsync();
    }
}
