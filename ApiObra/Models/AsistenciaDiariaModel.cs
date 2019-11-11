using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class AsistenciaDiariaModel
    {
        public long EmpleadoId { get; set; }
        public long JornalId { get; set; }
        public bool Asistio { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Salida { get; set; }
        public long? CausaId { get; set; }
        public string Observacion { get; set; }
    }
}
