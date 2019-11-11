using GestionObra.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.SalarioMinimo.DTOs
{
    public class SalarioMinimoDto : DtoBase
    {
        public DateTime FechaActualizacion { get; set; }
        public decimal Salario { get; set; }
    }
}
