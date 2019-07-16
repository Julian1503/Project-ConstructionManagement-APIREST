using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class ComprobanteSalidaModel : ComprobanteModel
    {
        public Perioricidad Perioricidad { get; set; }
        public TipoComprobanteSalida TipoComprobanteSalida { get; set; }
    }
}
