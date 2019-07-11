using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class TipoGasto : EntityBase
    {
        public string Descripcion { get; set; }

        //Conexiones
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
