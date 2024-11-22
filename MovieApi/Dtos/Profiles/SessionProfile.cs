using AutoMapper;
using MovieApi.Models;

namespace MovieApi.Dtos.Profiles
{
    public class SessionProfile : Profile
    {

        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>().ReverseMap();
            CreateMap<Session, ResponseSessionDto>()
                .ForMember(sessionDto => sessionDto.Room, opt => opt.MapFrom(session => session.Room))
                .ForMember(sessionDto => sessionDto.Movie, opt => opt.MapFrom(session => session.Movie));
        }

    }

}
