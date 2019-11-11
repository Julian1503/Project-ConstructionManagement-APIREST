using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.CondicionIva.DTOs;

namespace GestionObra.Interfaces.Empresa.DTOs
{
    public class EmpresaDto : DtoBase
    {
        public long? CondicionIvaId { get; set; }
        public CondicionIvaDto CondicionIva { get; set; }
        public string RazonSocial { get; set; }
        public string NombreFantasia { get; set; }
        public string Cuit { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Sucursal { get; set; }
        public string Path { get; set; }
    }
}
