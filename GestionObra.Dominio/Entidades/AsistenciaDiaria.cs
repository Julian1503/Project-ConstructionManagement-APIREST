using System;

namespace GestionObra.Dominio.Entidades
{
    public class AsistenciaDiaria : EntityBase
    {
        public long EmpleadoId { get; set; }
        public long JornalId { get; set; }
        public bool Asistio { get; set; }
        public TimeSpan Entrada { get; set; }
         public TimeSpan Salida { get; set; }
        public long? CausaId { get; set; }
        public string Observacion { get; set; }

        public virtual Jornal Jornal { get; set; }
        public virtual CausaFalta Causa { get; set; }
        public virtual Empleado Empleado{ get; set; }
    }
}