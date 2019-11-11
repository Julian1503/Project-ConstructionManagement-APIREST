namespace GestionObra.Dominio.Entidades
{
    using GestionObra.Constantes;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Obra : EntityBase
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Observacion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaEstimadaInicio { get; set; }
        public EstadoObra EstadoObra { get; set; }
        public long? PropietarioId { get; set; }
        public long EncargadoId { get; set; } //Persona
        public long? ZonaId { get; set; }
        //Conexiones
        public virtual Empleado Encargado { get; set; }
        public virtual Empresa Propietario { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<Jornal> Jornales { get; set; }
        public virtual ICollection<ComprobanteCompra> ComprobanteCompras { get; set; }
        public virtual ICollection<ObraEmpleado> ObraEmpleados { get; set; }
        public virtual ICollection<IngresoMaterial> IngresoMateriales { get; set; }
        public virtual ICollection<SalidaMaterial> SalidaMaterialesDe{ get; set; }
        public virtual ICollection<SalidaMaterial> SalidaMaterialesPara{ get; set; }
    }
}
