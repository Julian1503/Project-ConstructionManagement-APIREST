using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class PrecioModel
    {
        public long UsuarioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public long MaterialId { get; set; }
    }
}
