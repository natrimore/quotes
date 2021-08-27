using Quotes.Domain;
using System.Collections.Generic;

namespace Quotes.Infrastructure.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User FindByEmail(string email);

        void Create(User entity);
    }
}
