using AutoMapper;
using MovieApi.Models;

namespace MovieApi.Dtos.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();
            CreateMap<Address, ResponseAddressDto>();
        }

    }
}
