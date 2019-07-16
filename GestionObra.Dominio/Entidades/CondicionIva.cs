using GestionObra.Helpers;

namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.Linq;
    public class CondicionIva : EntityBase
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
        //Conexion
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
