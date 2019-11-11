using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Material.DTOs;

namespace GestionObra.Interfaces.Stock.DTOs
{
    public class StockDto : DtoBase
    {
        public long UsuarioId { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public long MaterialId { get; set; }
        public MaterialDto Material { get; set; }

    }
}
