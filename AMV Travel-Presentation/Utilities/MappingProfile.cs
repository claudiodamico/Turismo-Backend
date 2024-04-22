using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using AutoMapper;

namespace AMV_Travel_Presentation.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<Reserva,  ReservaDto>().ReverseMap();
        }
    }
}
