using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Comprobante.DTOs;

namespace GestionObra.Interfaces.ComprobanteEntrada.DTOs
{
    public class ComprobanteEntradaDto : ComprobanteDto
    {
        public TipoComprobanteEntrada TipoComprobanteEntrada { get; set; }
    }
}
