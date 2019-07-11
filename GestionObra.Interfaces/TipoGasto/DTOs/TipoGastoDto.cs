using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.TipoGasto.DTOs
{
    public class TipoGastoDto : DtoBase
    {
        public string Descripcion { get; set; }
    }
}
