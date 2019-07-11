namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Precio : EntityBase
    {
        public long UsuarioId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaActualizacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public long MaterialId { get; set; }

        //Conexiones
        public virtual Material Material { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
