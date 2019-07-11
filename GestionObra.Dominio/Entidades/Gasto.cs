using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionObra.Dominio.Entidades;

namespace GestionObra.Dominio
{
   public class Gasto : EntityBase
    {
        public long TipoGastoId { get; set; }
        public decimal Monto { get; set; }

        public long PresupuestoId { get; set; }
        //Conexiones
        public virtual TipoGasto TipoGasto { get; set; }
        public virtual Presupuesto Presupuesto { get; set; }
    }
}
