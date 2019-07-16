using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class ComprobanteEntradaModel : ComprobanteModel
    {
        public TipoComprobanteEntrada TipoComprobanteEntrada { get; set; }
    }
}
