using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.IngresoMaterial.DTOs
{
    public class IngresoMaterialDto : DtoBase
    {
        public DateTime FechaIngreso { get; set; }
        public long MaterialId { get; set; }
        public long ObraId { get; set; }
        public long PropietarioId { get; set; }
        public int CantidadUsado { get; set; }
        public int Cantidad { get; set; }
    }
}
