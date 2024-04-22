using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMV_Travel_Domain.Dtos
{
    public class TourDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Destino { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}
