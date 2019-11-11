using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GestionObra.Constantes
{
    public enum EstadoObra
    {
        Pendiente = 1,
        [Description("En Proceso")]
        Planificacion = 2,
        EnProceso = 3,
        Finalizada = 4
    }
}
