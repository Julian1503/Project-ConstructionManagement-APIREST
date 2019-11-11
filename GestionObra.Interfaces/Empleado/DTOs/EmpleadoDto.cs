using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Categoria.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Empleado.DTOs
{
    public class EmpleadoDto : DtoBase
    {
        public long Legajo { get; set; }
        public DateTime FechaIncio { get; set; }
        public long CategoriaId { get; set; }
        public CategoriaDto Categoria { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Dni { get; set; }
        public string Path { get; set; }
    }
}
