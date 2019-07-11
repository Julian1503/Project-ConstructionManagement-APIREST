using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Precio.DTOs
{
    public class PrecioDto : DtoBase
    {
        public long UsuarioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public long MaterialId { get; set; }
    }
}
