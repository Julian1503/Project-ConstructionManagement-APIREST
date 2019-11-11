using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class IngresoMaterial : EntityBase
    {
        [DataType(DataType.DateTime)]
        public DateTime FechaIngreso { get; set; }
        public long MaterialId { get; set; }
        public long ObraId { get; set; }
        public long EncargadoId { get; set; }
        public int Cantidad { get; set; }
        public int CantidadDevuelta { get; set; }
        //Conexiones
        public virtual Obra Obra { get; set; }
        public virtual Empleado Encargado { get; set; }
        public virtual Material Material { get; set; }

    }
}
