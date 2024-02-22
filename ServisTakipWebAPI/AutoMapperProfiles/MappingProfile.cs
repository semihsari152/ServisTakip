using AutoMapper;
using ServisTakipWebAPI.Models.Request;
using ServisTakipWebAPI.Models.Response;
using ServisTakipWebAPI.Models;

namespace ServisTakipWebAPI.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FaultTrack, FaultTrackResponseModel>();
            CreateMap<Product, ProductRequestModel>();
            CreateMap<Customer, CustomerRequestModel>();
        }
    }
}
