using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
   public class Jornal :EntityBase
    {
        public int NumeroOrden { get; set; }
        public long ObraId { get; set; }
        public decimal Viatico { get; set; }
        public decimal Multas { get; set; }
        public decimal Gasolina { get; set; }
        public decimal Repuestos { get; set; }
        public decimal Otros { get; set; }
        public DateTime DiaJornal { get; set; }

        public virtual Obra Obra { get; set; }
        public virtual IEnumerable<AsistenciaContratista> AsistenciaContratista { get; set; }
        public virtual IEnumerable<AsistenciaDiaria> AsistenciaDiarias { get; set; }
        public virtual IEnumerable<JornalMaterial> JornalMateriales { get; set; }
    }
}
