using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionObra.Constantes;

namespace ApiObra.Models
{
    public class PresupuestoModel
    {
        public long Numero { get; set; }
        public string Titulo { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaPresupuesto { get; set; }
        public long EmpresaId { get; set; } // nuevo
        public long ObraId { get; set; } // nuevo
        public decimal PrecioCliente { get; set; }
        public decimal Beneficio { get; set; }
        public decimal ImprevistoPorcentual { get; set; }
        public decimal Impuestos { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Cobrado { get; set; }
        public EstadoPresupuesto EstadoPresupuesto { get; set; }
        public bool Facturado { get; set; }
        public EstadoDeCobro EstadoDeCobro { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public long? Cae { get; set; }
        public long? NumeroFacturacion { get; set; }

        public decimal Descuento { get; set; }
        public decimal Interes { get; set; }
        public decimal Percepciones { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Iva { get; set; }
    }
}
