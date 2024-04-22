using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMV_Travel_Domain.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public int TourId { get; set; }
    }
}
