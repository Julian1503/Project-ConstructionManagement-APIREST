using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class AsistenciaContratista : EntityBase
    {
        public long ContratistaId { get; set; }
        public long JornalId { get; set; }
        public TimeSpan Entrada { get; set; }
        public TimeSpan Salida { get; set; }
        public string Observacion { get; set; }

        public virtual Jornal Jornal { get; set; }
        public virtual Contratista Contratista { get; set; }
    }
}
