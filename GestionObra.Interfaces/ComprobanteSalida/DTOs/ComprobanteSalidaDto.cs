using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Comprobante.DTOs;

namespace GestionObra.Interfaces.ComprobanteSalida.DTOs
{
    public class ComprobanteSalidaDto : ComprobanteDto
    {
        public Perioricidad Perioricidad { get; set; }
        public TipoComprobanteSalida TipoComprobanteSalida { get; set; }
    }
}
