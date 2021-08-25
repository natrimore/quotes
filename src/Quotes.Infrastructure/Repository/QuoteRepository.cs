using Microsoft.EntityFrameworkCore;
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
        public Task<bool> CreateAsync(Quote entity)
        {
            _context.Quotes.Add(entity);

            return SaveChangesAsync();
        }

        public Task<List<Quote>> FindAllAsync()
        {
            return _context.Quotes.ToListAsync();
        }

        public Task<List<Quote>> FindByAuthorAsync(string author)
        {
            return _context.Quotes.Where(w => w.Author == author).ToListAsync();
        }

        public Task<List<Quote>> FindByCategoryAsync(string category)
        {
            return _context.Quotes.Where(w => w.Category == category).ToListAsync();
        }

        public Task<Quote> FindByIdAsync(int id)
        {
            return _context.Quotes.SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var entity = _context.Quotes.Find(id);

            if (entity != null)
            {
                _context.Remove(entity);

                return await SaveChangesAsync();
            }

            return false;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Quote> UpdateAsync(Quote entity)
        {
            entity = _context.Quotes.Update(entity).Entity;

            if (entity != null)
            {
                return entity;
            }

            return null;
        }
    }
}
