using Quotes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.Infrastructure.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly QuoteContext _context;

        public QuoteRepository(QuoteContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> CreateAsync(Quote entity)
        {
            _context.Quotes.Add(entity);
            return true;
        }

        public List<Quote> FindAllAsync()
        {
            return _context.Quotes.ToList();
        }

        public async Task<List<Quote>> FindByAuthorAsync(string author)
        {
            return _context.Quotes.Where(w => w.Author == author).ToList();
        }

        public async Task<List<Quote>> FindByCategoryAsync(string category)
        {
            return _context.Quotes.Where(w => w.Category == category).ToList();
        }

        public async Task<Quote> FindByIdAsync(Guid id)
        {
            return _context.Quotes.Find(s => s.Id == id);
        }

        public Quote GetRandomQuote()
        {
            var quoteCount = _context.Quotes.Count();
            Random random = new Random();
            var index = random.Next(quoteCount);
            return _context.Quotes[index];
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var entity = _context.Quotes.FirstOrDefault(f => f.Id == id);

            if (entity != null)
            {
                _context.Quotes.Remove(entity);

                return true;
            }

            return false;
        }

        public void RemoveRange(List<Quote> quotes)
        {
            foreach (var quote in quotes)
            {
                _context.Quotes.Remove(quote);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
            //return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateAsync(Quote entity)
        {
            var index = _context.Quotes.FindIndex(f => f.Id == entity.Id);
            if (index != -1)
            {
                _context.Quotes[index] = new Quote()
                {
                    Id = entity.Id,
                    Author = entity.Author,
                    Category = entity.Category,
                    Created = entity.Created,
                    QuoteName = entity.QuoteName
                };

                return true;
            }
            
            return false;
        }
    }
}
