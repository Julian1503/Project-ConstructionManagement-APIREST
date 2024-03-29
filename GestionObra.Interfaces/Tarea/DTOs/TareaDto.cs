﻿using System;
using System.Collections.Generic;
using System.Text;
using GestionObra.Constantes;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.DescripcionTarea.DTOs;

namespace GestionObra.Interfaces.Tarea.DTOs
{
    public class TareaDto : DtoBase
    {
        public long DescripcionTareaId { get; set; }
        public DescripcionTareaDto DescripcionTarea { get; set; }
        public int NumeroOrden { get; set; }
        public string Observacion { get; set; }
        public EstadoTarea Estado { get; set; }

        public long ObraId { get; set; }

        public TimeSpan Duracion { get; set; }

        public TimeSpan TiempoEmpleado { get; set; }
        public bool Precede { get; set; }
    }
}
