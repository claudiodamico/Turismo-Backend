using AMV_Travel_Domain.Commands;
using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using AutoMapper;

namespace AMV_Travel_Application.Services
{
    public interface ITourService
    {
        List<Tour> MostrarTours();
        Tour AgregarTour(TourDto tour);
        Task<Tour> ObtenerTourPorId(int tourId);
        Task<bool> EliminarTour(int Id);
    }
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository,
            IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public Tour AgregarTour(TourDto tour)
        {
            var tourMapeado = _mapper.Map<Tour>(tour);
            _tourRepository.AgregarTour(tourMapeado);

            return tourMapeado;
        }

        public List<Tour> MostrarTours()
        {
            return _tourRepository.MostrarTours();
        }

        public async Task<Tour> ObtenerTourPorId(int tourId)
        {
            return await _tourRepository.ObtenerTourPorId(tourId); 
        }

        public async Task<bool> EliminarTour(int Id)
        {
            return await _tourRepository.EliminarTour(Id);
        }
    }
}
