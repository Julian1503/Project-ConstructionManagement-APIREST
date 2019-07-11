using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Usuario.DTOs
{
    public class UsuarioDto : DtoBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PersonaId { get; set; }
        public bool EstaBloqueado { get; set; }
    }
}
