namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Stock : EntityBase
    {
        public long UsuarioId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaActualizacion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public long MaterialId { get; set; }
        
        //Conexiones
        public virtual Usuario Usuario { get; set; }
        public virtual Material Material { get; set; }
    }
}
