using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Material.DTOs
{
    public class MaterialDto : DtoBase
    {
        public string Codigo { get; set; }
        public TipoMaterial TipoMaterial { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Path { get; set; }
    }
}
