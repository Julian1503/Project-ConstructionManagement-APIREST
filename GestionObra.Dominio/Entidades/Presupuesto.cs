using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;

namespace GestionObra.Dominio.Entidades
{
    public class Presupuesto : EntityBase
    {
        public decimal ImprevistoPesos { get; set; }
        public decimal ImprevistoPorcentual { get; set; }
        public EstadoPresupuesto EstadoPresupuesto { get; set; }

        //Conexiones
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
