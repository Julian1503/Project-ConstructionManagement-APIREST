using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Contratista.DTOs;
using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.AsistenciaContratista.DTOs
{
    public class AsistenciaContratistaDto : DtoBase
    {
        public long ContratistaId { get; set; }
        public long JornalId { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Salida { get; set; }
        public string Observacion { get; set; }

        public virtual JornalDto Jornal { get; set; }
        public virtual ContratistaDto Contratista { get; set; }
    }
}
