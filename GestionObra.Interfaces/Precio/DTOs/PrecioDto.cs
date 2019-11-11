using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Material.DTOs;
using GestionObra.Interfaces.Usuario.DTOs;

namespace GestionObra.Interfaces.Precio.DTOs
{
    public class PrecioDto : DtoBase
    {
        public UsuarioDto Usuario { get; set; }
        public long UsuarioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public long MaterialId { get; set; }
        public MaterialDto Material { get; set; }
    }
}
