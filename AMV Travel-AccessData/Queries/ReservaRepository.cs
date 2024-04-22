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

        public async Task EliminarReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró una reserva con el ID {id} para eliminar.");
            }
        }
    }
}
