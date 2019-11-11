namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class CuentaCorriente : EntityBase
    {
        public long BancoId { get; set; }
        public decimal MontoMaximo { get; set; }


        //A cobrar es campo calculado

        //Conexiones
        public virtual IEnumerable<Operacion> Operaciones { get; set; } 
        public virtual Banco Banco { get; set; }
    }
}
