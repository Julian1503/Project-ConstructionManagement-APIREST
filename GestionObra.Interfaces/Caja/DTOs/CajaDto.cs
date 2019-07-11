using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.Caja.DTOs
{
   public class CajaDto:DtoBase
    {
        public long UsuarioAperturaId { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal MontoCierre { get; set; }
        public long? UsuarioCierreId { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime? FechaCierre { get; set; }
        public decimal MontoSistema { get; set; }
        public decimal Diferencia { get; set; }
    }
}
