using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empleado.DTOs;
using GestionObra.Interfaces.Identificacion.DTOs;

namespace GestionObra.Interfaces.Usuario.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IdentificacionDto Identificacion { get; set; }
        public long IdentificacionId { get; set; }
        public EmpleadoDto Empleado { get; set; }

        public long EmpleadoId { get; set; }
        public bool EstaBloqueado { get; set; }
    }
}
