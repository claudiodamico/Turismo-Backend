using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMV_Travel_Domain.Dtos
{
   public class ErrorDto
    {
        public string codigoError { get; set; } = null!;
        public string descripcion { get; set; } = null!;
    }
}
