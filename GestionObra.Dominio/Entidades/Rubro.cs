namespace GestionObra.Dominio
{
    using Constantes;
    using Entidades;
    using System.Collections.Generic;
    using System.Linq;
    public class Rubro : EntityBase
    {
        //Propiedades
        public string Descripcion { get; set; }
        public long Codigo { get; set; }
        public TipoRubro TipoRubro { get; set; }

        //Conexiones
        public virtual ICollection<SubRubro> SubRubros { get; set; }
    }
}
