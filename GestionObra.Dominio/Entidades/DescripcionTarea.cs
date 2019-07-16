using GestionObra.Helpers;

namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.Linq;
    public class DescripcionTarea : EntityBase
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
        public virtual ICollection<Tarea> Tareas { get; set; }

    }
}
