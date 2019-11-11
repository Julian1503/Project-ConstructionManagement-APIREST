using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class ObraEmpleado : EntityBase
    {
        public long ObraId { get; set; }
        public long EmpleadoId { get; set; }

        public virtual Obra Obra { get; set; }
        public virtual Empleado Empleado { get; set; }
    }
}