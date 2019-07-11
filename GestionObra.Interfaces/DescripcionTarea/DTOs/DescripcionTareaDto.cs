using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Interfaces.Base;

namespace GestionObra.Interfaces.DescripcionTarea.DTOs
{
    public class DescripcionTareaDto :DtoBase
    {
        public string Descripcion { get; set; }
    }
}
