using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiObra.Models
{
    public class EmpleadoModel
    {
        public long Legajo { get; set; }
        public DateTime FechaIncio { get; set; }
        public long CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Path { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }
    }
}
