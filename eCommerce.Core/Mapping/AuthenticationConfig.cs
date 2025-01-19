using AutoMapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mapping
{
    public class AuthenticationConfig : Profile
    {
        public AuthenticationConfig()
        {
            CreateMap<ApplicationUser, AuthenticationResponse>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest=>dest.Success , opt=>opt.Ignore())
                .ForMember(dest => dest.Token, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, ApplicationUser>()
                .ForMember(dest => dest.PersonName, opt => opt.MapFrom(src => src.PersonName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();

            CreateMap<LoginRequest, ApplicationUser>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ReverseMap();
        }
    }
}
