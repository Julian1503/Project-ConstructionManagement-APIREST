using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Obra.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Jornal.DTOs
{
    public class ObraEmpleadoDto :DtoBase
    {
        public long ObraId { get; set; }
        public ObraDto Obra { get; set; }
        public long EmpleadoId { get; set; }
        public EmpleadoDto Empleado { get; set; }
    }
}
