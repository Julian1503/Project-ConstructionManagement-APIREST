namespace GestionObra.Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Obra : EntityBase
    {
        public string Descripcion { get; set; }
        public string Codigo { get; set; }
        public string Observiacion { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaEstimadaInicio { get; set; }
        public long PropietarioId { get; set; }
        public long EncargadoId { get; set; } //Persona
        public long? ZonaId { get; set; }
        //Conexiones
        public virtual Persona Encargado { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
        public virtual ICollection<IngresoMaterial> IngresoMateriales { get; set; }
        public virtual ICollection<SalidaMaterial> SalidaMaterialesDe{ get; set; }
        public virtual ICollection<SalidaMaterial> SalidaMaterialesPara{ get; set; }
    }
}
