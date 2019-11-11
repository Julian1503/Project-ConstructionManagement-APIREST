using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GestionObra.Constantes
{
    public enum EstadoCheque
    {
        [Description("En stock")]
        EnStock = 1,
        Cobrado=2,
        Usado=3
    }
}
