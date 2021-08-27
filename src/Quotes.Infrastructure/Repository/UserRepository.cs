using Quotes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quotes.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly QuoteContext _context;

        public UserRepository(QuoteContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public void Create(User entity)
        {
            _context.Users.Add(entity);
        }

        public User FindByEmail(string email)
        {
            email = email.ToLowerInvariant();
            var entity = _context.Users.FirstOrDefault(f => f.Email == email);

            return entity;
        }

        public List<User> GetAll()
        {
            return _context.Users;
        }
    }
}
