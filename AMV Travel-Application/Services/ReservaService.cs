using AMV_Travel_Domain.Commands;
using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using AutoMapper;

namespace AMV_Travel_Application.Services
{
    public interface IReservaService
    {
        Task<IEnumerable<ReservaDto>> MostrarInformacion();
        Task<Reserva> CrearReserva(Reserva reserva);
        Task<bool> EliminarReserva(int id);
    }
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public ReservaService(IReservaRepository reservaRepository,
            ITourService tourService, IMapper mapper)
        {
            _reservaRepository = reservaRepository;
            _tourService = tourService;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReservaDto>> MostrarInformacion()
        {
            var reservas = await _reservaRepository.MostrarInformacion();
            return _mapper.Map<IEnumerable<ReservaDto>>(reservas);
        }

        public async Task<Reserva> CrearReserva(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva));

            // Verificar la disponibilidad del tour
            var tour = await _tourService.ObtenerTourPorId(reserva.TourId);
            if (tour == null)
                throw new Exception("El tour no está disponible para las fechas seleccionadas.");

            return await _reservaRepository.CrearReserva(reserva);
        }

        public async Task<bool> EliminarReserva(int id)
        {
            var reserva = await _reservaRepository.ObtenerReservaPorId(id);
            if (reserva == null)
            {
                throw new KeyNotFoundException($"No se encontró una reserva con el ID {id}.");
            }

            
            return true;
        }
    }
}
