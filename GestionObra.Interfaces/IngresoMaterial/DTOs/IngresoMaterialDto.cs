using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Empresa.DTOs;
using GestionObra.Interfaces.Material.DTOs;
using GestionObra.Interfaces.Obra.DTOs;

namespace GestionObra.Interfaces.IngresoMaterial.DTOs
{
    public class IngresoMaterialDto : DtoBase
    {
        public DateTime FechaIngreso { get; set; }
        public long MaterialId { get; set; }
        public long ObraId { get; set; }
        public long EncargadoId { get; set; }
        public int CantidadDevuelta { get; set; }
        public int Cantidad { get; set; }
        public MaterialDto Material { get; set; }
        public ObraDto Obra { get; set; }
        public EmpleadoDto Encargado { get; set; }
    }
}
