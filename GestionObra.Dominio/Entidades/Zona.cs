using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class Zona : EntityBase
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set
            {
                _descripcion = string.Join(' ', value.Split(' ')
                    .Select(x => x[0].ToString().ToUpper() + x.Substring(1).ToUpper())
                    .ToArray());
            }
        }

        //Conexiones
        public virtual ICollection<Obra> Obras { get; set; }
    }
}
