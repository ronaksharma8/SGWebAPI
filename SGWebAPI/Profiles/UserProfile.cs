using AutoMapper;
using SGWebAPI.Models;

namespace SGWebAPI.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateOrderRequest, CreateOrderResponse>();
        }

    }
}
