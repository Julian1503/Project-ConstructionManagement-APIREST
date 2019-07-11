namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.Linq;
    public class Banco : EntityBase
    {
        public string Descripcion { get; set; }

        //Conexiones
        public virtual ICollection<CuentaCorriente> CuentaCorrientes { get; set; }
    }
}
