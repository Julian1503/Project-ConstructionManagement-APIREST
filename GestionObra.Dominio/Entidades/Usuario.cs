using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class Usuario : EntityBase
    {
        //Propiedades
        public string UserName { get; set; }
        public string Password { get; set; }
        public long EmpleadoId { get; set; }
        public string Token { get; set; }
        public bool EstaBloqueado { get; set; }
        public long IdentificacionId { get; set; }

        //Conexiones
        public virtual Identificacion Identificacion { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
        public virtual ICollection<ComprobanteSalida> ComprobantesSalida { get; set; }
        public virtual ICollection<ComprobanteEntrada> ComprobantesEntrada  { get; set; }
        public virtual ICollection<Caja> CajaApertura { get; set; }
        public virtual ICollection<Caja> CajaCierre { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
