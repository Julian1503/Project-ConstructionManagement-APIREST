using System;
using System.Collections;
using System.Collections.Generic;

namespace GestionObra.Dominio.Entidades
{
    public class Empleado : EntityBase
    {
        public long Legajo { get; set; }
        public DateTime FechaIncio { get; set; }
        public long CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Path { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }

        public virtual Categoria Categoria{ get; set; }
        public virtual ICollection<Obra> Obras { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<IngresoMaterial> IngresoMateriales { get; set; }
        public virtual ICollection<SalidaMaterial> SalidaMateriales { get; set; }
        public virtual IEnumerable<AsistenciaDiaria> AsistenciaDiarias { get; set; }
        public virtual IEnumerable<ObraEmpleado> ObraEmpleados{ get; set; }
    }
}