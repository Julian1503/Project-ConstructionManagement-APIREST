using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Causa.DTOs;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.AsistenciaDiaria.DTOs
{
   public class AsistenciaDiariaDto : DtoBase
    {
        public long EmpleadoId { get; set; }
        public long JornalId { get; set; }
        public bool Asistio { get; set; }
        public TimeSpan Entrada { get; set; }
         public TimeSpan Salida { get; set; }
        public long? CausaId { get; set; }
        public string Observacion { get; set; }

        public JornalDto Jornal { get; set; }
        public CausaFaltaDto Causa { get; set; }
        public EmpleadoDto Empleado { get; set; }
    }
}
