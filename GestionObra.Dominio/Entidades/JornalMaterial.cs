using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Dominio.Entidades
{
  public class JornalMaterial : EntityBase
    {
        public long MaterialId { get; set; }
        public long JornalId { get; set; }
        public int CantidadUsado { get; set; }

        public virtual Material Material { get; set; }
        public virtual Jornal Jornal { get; set; }

    }
}
