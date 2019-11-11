using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class UsuarioModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
        public long IdentificacionId { get; set; }
        public long EmpleadoId { get; set; }
        public bool EstaBloqueado { get; set; }
    }
}
