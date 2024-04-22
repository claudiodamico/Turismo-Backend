using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMV_Travel_Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        [Display(Name = "Destino")]
        public string Destino { get; set; }
        [Required]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }
        [Required]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaFin { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal Precio { get; set; }
    }
}
