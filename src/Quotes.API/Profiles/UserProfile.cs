using AutoMapper;
using Quote.ViewModels;
using Quotes.Domain;

namespace Quotes.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                .ReverseMap();
        }
    }
}
