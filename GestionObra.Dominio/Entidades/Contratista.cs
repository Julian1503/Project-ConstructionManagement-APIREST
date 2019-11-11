using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
    public class Contratista : EntityBase
    {
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Sucursal { get; set; }
        public string Path { get; set; }

        //Conexiones
        public virtual ICollection<AsistenciaContratista> AsistenciasContratista { get; set; }
    }
}
