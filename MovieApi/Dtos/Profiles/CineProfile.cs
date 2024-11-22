using AutoMapper;
using MovieApi.Models;

namespace MovieApi.Dtos.Profiles
{
    public class CineProfile : Profile
    {

        public CineProfile() 
        {
            CreateMap<CreateCineDto, Cine>();
            CreateMap<UpdateCineDto, Cine>().ReverseMap();
            CreateMap<Cine, ResponseCineDto>().ForMember(cineDto => cineDto.Address, opt => opt.MapFrom(cine => cine.Address));
        }

    }
}
