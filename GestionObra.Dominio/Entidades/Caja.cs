using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using GestionObra.Dominio.Entidades;

namespace GestionObra.Dominio
{
    public class Caja : EntityBase
    {
       
        [DataType(DataType.DateTime)]
        public DateTime? FechaCierre { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaApertura { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal MontoCierre { get; set; }
        public long UsuarioAperturaId { get; set; }
        public long? UsuarioCierreId { get; set; }
        public decimal MontoSistema { get; set; }
        public decimal Diferencia { get; set; }

        //Conexion
        public virtual ICollection<DetalleCaja> DetalleCajas { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
        public virtual Usuario UsuarioApertura { get; set; }
        public virtual Usuario UsuarioCierre { get; set; }
    }
}
