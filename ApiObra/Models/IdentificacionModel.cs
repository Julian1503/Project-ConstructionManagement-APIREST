using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class IdentificacionModel
    {
        public bool Tesoreria { get; set; }
        public bool Obra { get; set; }
        public bool Configuracion { get; set; }
        public bool Administracion { get; set; }
        public bool Usuarios { get; set; }
    }
}
