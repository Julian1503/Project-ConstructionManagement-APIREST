
namespace GestionObra.Dominio.Entidades
{
    using Constantes;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Tarea : EntityBase
    {
        public long DescripcionTareaId { get; set; }
        public int NumeroOrden { get; set; }
        public bool Precede { get; set; }
        public string Observacion { get; set; }
        public EstadoTarea Estado { get; set; }

        public long ObraId { get; set; }
        
        [DataType(DataType.Duration)]
        public TimeSpan Duracion { get; set; }

        [DataType(DataType.Duration)]
        public TimeSpan TiempoEmpleado { get; set; }

        //Conexiones
        public virtual DescripcionTarea DescripcionTarea { get; set; }
        public virtual Obra Obra { get; set; }
    }
}
