using GestionObra.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Identificacion.DTOs
{
   public class IdentificacionDto : DtoBase
    {
        public bool Tesoreria { get; set; }
        public bool Obra { get; set; }
        public bool Configuracion { get; set; }
        public bool Administracion { get; set; }
        public bool Usuarios { get; set; }
    }
}
