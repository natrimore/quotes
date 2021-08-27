using Quotes.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Infrastructure.Repository
{
    public interface IQuoteRepository
    {
        Quote GetRandomQuote(); 
        List<Quote> FindAllAsync();

        Task<Quote> FindByIdAsync(Guid id);

        Task<List<Quote>> FindByAuthorAsync(string author);

        Task<List<Quote>> FindByCategoryAsync(string category);

        Task<bool> RemoveAsync(Guid id);

        void RemoveRange(List<Quote> quotes);

        Task<bool> CreateAsync(Quote entity);

        Task<Quote> UpdateAsync(Quote entity);

        Task<bool> SaveChangesAsync();
    }
}
