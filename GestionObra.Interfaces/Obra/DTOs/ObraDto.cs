using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Empresa.DTOs;
using GestionObra.Interfaces.Zona.DTOs;

namespace GestionObra.Interfaces.Obra.DTOs
{
    public class ObraDto:DtoBase
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaEstimadaInicio { get; set; }
        public long? PropietarioId { get; set; }
        public long EncargadoId { get; set; } //Persona
        public long? ZonaId { get; set; }
        public EmpresaDto Propietario { get; set; }
        public EmpleadoDto Encargado { get; set; } //Persona
        public ZonaDto Zona { get; set; }
        public EstadoObra EstadoObra { get; set; }
    }
}
