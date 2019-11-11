using GestionObra.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class SubRubro : EntityBase
    {
        public long Codigo { get; set; }
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
        public long RubroId { get; set; }
        //Conexion
        public virtual Rubro Rubro { get; set; }
        public virtual ICollection<ComprobanteSalida> ComprobantesSalida { get; set; }
        public virtual ICollection<ComprobanteEntrada> ComprobantesEntrada { get; set; }
    }
}
