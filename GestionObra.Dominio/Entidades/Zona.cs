using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestionObra.Helpers;

namespace GestionObra.Dominio.Entidades
{
    public class Zona : EntityBase
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
        public virtual ICollection<Obra> Obras { get; set; }
    }
}
