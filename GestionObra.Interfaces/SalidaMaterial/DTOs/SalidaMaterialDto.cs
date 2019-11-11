using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Material.DTOs;
using GestionObra.Interfaces.Obra.DTOs;

namespace GestionObra.Interfaces.SalidaMaterial.DTOs
{
    public class SalidaMaterialDto : DtoBase
    {
        public DateTime FechaEgreso { get; set; }
        public long MaterialId { get; set; }
        public long DeObraId { get; set; }
        public long ResponsableId { get; set; }
        public long ParaObraId { get; set; }
        public int Cantidad { get; set; }

        public ObraDto DeObra { get; set; }
        public MaterialDto Material { get; set; }
        public EmpleadoDto Responsable { get; set; }
        public ObraDto ParaObra { get; set; }

    }
}
