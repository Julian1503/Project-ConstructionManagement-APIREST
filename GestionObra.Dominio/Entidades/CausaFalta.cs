
using GestionObra.Helpers;
using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class CausaFalta : EntityBase
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

        public virtual IEnumerable<AsistenciaDiaria> AsistenciaDiarias { get; set; }
    }
}