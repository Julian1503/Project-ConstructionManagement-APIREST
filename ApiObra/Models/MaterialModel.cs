using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class MaterialModel
    {
        public string Codigo { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Path { get; set; }
    }
}
