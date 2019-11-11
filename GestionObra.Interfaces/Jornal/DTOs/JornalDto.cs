using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Obra.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Jornal.DTOs
{ 
    public class JornalDto : DtoBase
    {
        public long ObraId { get; set; }
        public virtual ObraDto Obra { get; set; }
        public decimal Viatico { get; set; }
        public DateTime DiaJornal { get; set; }
        public int NumeroOrden { get; set; }
        public decimal Repuestos { get; set; }
        public decimal Multas { get; set; }
        public decimal Otros { get; set; }
        public decimal Gasolina { get; set; }
    }
}
