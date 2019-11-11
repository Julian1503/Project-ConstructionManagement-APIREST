using GestionObra.Helpers;
using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class Categoria : EntityBase
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
        public long SalarioMinimoId { get; set; }

        public virtual IEnumerable<SalarioMinimo> SalariosMinimo { get; set; }
        public virtual IEnumerable<Empleado> Empleados { get; set; }
    }
}