using GestionObra.Helpers;

namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    public class Banco : EntityBase
    {
        private string _descripcion;

        public string Descripcion
        {
            get
            {
               return _descripcion;
            }
            set
            {
                _descripcion = Capitalize.CapitalizeFirstLetter(value);
            }
        }

        //Conexiones
        public virtual ICollection<CuentaCorriente> CuentaCorrientes { get; set; }
    }
}
