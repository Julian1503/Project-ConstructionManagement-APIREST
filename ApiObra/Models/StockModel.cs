using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class StockModel
    {
        public long UsuarioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public long MaterialId { get; set; }
    }
}
