using AMV_Travel_Domain.Dtos;
using AMV_Travel_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMV_Travel_Domain.Commands
{
    public interface IReservaRepository
    {
        Task<IEnumerable<Reserva>> MostrarInformacion();
        Task<Reserva> CrearReserva(Reserva reserva);
        Task<Reserva> ObtenerReservaPorId(int id);
        Task EliminarReserva(int id);
    }
}
