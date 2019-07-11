namespace GestionObra.Dominio.Entidades
{
    using System.Collections.Generic;
    using System.Linq;
    public class DescripcionTarea : EntityBase
    {
        public string Descripcion { get; set; }

        //Conexiones
        public virtual ICollection<Tarea> Tareas { get; set; }

    }
}
