using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using GestionObra.Constantes;

namespace GestionObra.Dominio.Entidades
{
    public class Presupuesto : EntityBase
    {
        public long Numero { get; set; }
        public DateTime FechaPresupuesto { get; set; }
        public EstadoPresupuesto EstadoPresupuesto { get; set; }
        public long EmpresaId { get; set; } 
        public string Titulo { get; set; }
        public string Observacion { get; set; }
        public string Descripcion { get; set; }
        public long ObraId { get; set; }
        public decimal PrecioCliente { get; set;}
        public EstadoDeCobro EstadoDeCobro { get; set; }
        public decimal Cobrado { get; set; }
        public decimal Beneficio { get; set; }
        public decimal ImprevistoPorcentual { get; set; }
        public decimal Impuestos { get; set; }
        public decimal SubTotal { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public bool Facturado { get; set; }
        public long? Cae { get; set; }
        public long? NumeroFacturacion { get; set; }


        public decimal Descuento { get; set; }
        public decimal Interes { get; set; }
        public decimal Percepciones { get; set; }
        public decimal Retenciones { get; set; }
        public decimal Iva { get; set; }
        //Conexiones
        public virtual Obra Obra { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Gasto> Gastos { get; set; }
    }
}
