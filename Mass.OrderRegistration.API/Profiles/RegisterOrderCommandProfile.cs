using AutoMapper;
using Mass.Registration.Shared;

namespace Mass.OrderRegistration.API.Profiles
{
    public class RegisterOrderCommandProfile : Profile
    {
        public RegisterOrderCommandProfile()
        {
            CreateMap<RegisterOrder, RegisterOrderCommandProfile>();
        }
    }
}
