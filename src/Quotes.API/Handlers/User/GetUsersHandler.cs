using AutoMapper;
using Quote.ViewModels;
using Quotes.API.Queries;
using Quotes.Infrastructure.Repository;
using Quotes.Shared.Handlers;
using Quotes.Shared.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Handlers.User
{
    public class GetUsersHandler : IQueryHandler<GetUsers, PagedResult<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<PagedResult<UserViewModel>> HandleAsync(GetUsers query)
        {
            var users = _userRepository.GetAll();

            var models = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return new PagedResult<UserViewModel> { Data = models, Total = models.Count() };
        }
    }
}
