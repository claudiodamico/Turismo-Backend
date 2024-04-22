using AMV_Travel_AccessData.Data;
using AMV_Travel_Domain.Commands;
using AMV_Travel_Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AMV_Travel_AccessData.Queries
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AMV_TravelDbContext _context;

        public ReservaRepository(AMV_TravelDbContext context)
        {
            _context = context;
        }

        public async Task<Reserva> CrearReserva(Reserva reserva)
        {
            if (reserva == null)
                throw new ArgumentNullException(nameof(reserva));

            await _context.Reserva.AddAsync(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        public async Task<IEnumerable<Reserva>> MostrarInformacion()
        {
            var reserva = await _context.Reserva.ToListAsync();
            return reserva;
        }

        public async Task<Reserva> ObtenerReservaPorId(int id)
        {
            return await _context.Reserva.FindAsync(id);
        }

        public async Task<bool> EliminarReserva(int id)
        {
            var reserva = await _context.Tours.FindAsync(id);
            if (reserva == null)
            {
                return false;
            }

            _context.Tours.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
