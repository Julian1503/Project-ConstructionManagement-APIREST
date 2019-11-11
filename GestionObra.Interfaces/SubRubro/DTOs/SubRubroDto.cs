using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Rubro.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.SubRubro.DTOs
{
   public class SubRubroDto : DtoBase
    {
        public string Descripcion { get; set; }
        public long RubroId { get; set; }
        public RubroDto Rubro { get; set; }
        public long Codigo { get; set; }
    }
}
