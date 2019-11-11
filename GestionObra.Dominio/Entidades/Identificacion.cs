using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class Identificacion : EntityBase
    {
        public bool Tesoreria { get; set; }
        public bool Obra { get; set; }
        public bool Configuracion { get; set; }
        public bool Administracion { get; set; }
        public bool Usuarios { get; set; }

        public virtual Usuario Usuario{ get; set; }
    }
}
