using System;
using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class SalarioMinimo : EntityBase
    {
        public DateTime FechaActualizacion { get; set; }
        public decimal Salario { get; set; }
        public long CategoriaId { get; set; }
        public virtual  Categoria Categoria { get; set; }
    }
}