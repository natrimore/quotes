using Quotes.API.Commands;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Handlers.User
{
    public class SubscribeUserHandler : ICommandHandler<SubscribeUser>
    {
        private readonly IUserRepository _userRepository;
        public SubscribeUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task HandleAsync(SubscribeUser command)
        {
            var entity = _userRepository.FindByEmail(command.Email);
            if (entity == null)
            {
                entity = new Domain.User() { Email = command.Email, Id = Guid.NewGuid(), IsSubscribed = command.IsSubscribed, UserName = command.Email };
                _userRepository.Create(entity);
            }
            else
            {

            }
        }
    }
}
