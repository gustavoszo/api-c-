using AutoMapper;
using MovieApi.Models;

namespace MovieApi.Dtos.Profiles
{
    public class RoomProfile : Profile
    {

        public RoomProfile()
        {
            CreateMap<CreateRoomDto, Room>();
            CreateMap<Room, ResponseRoomDto>();
        }

    }
}
