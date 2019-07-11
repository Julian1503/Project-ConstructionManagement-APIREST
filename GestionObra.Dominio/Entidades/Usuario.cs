using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class Usuario : EntityBase
    {
        //Propiedades
        public string UserName { get; set; }
        public string Password { get; set; }
        public long LimitacionesId { get; set; }
        public long PersonaId { get; set; }
        public bool EstaBloqueado { get; set; }

        //Conexiones
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
        public virtual ICollection<Comprobante> Comprobantes { get; set; }
        public virtual ICollection<Caja> CajaApertura { get; set; }
        public virtual ICollection<Caja> CajaCierre { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
