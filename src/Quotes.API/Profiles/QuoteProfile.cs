using AutoMapper;
using Quote.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.API.Profiles
{
    public class QuoteProfile : Profile
    {
        public QuoteProfile()
        {
            CreateMap<Domain.Quote, QuoteViewModel>()
                .ReverseMap();
        }
    }
}
