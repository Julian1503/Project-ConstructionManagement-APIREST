using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Material.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionObra.Interfaces.Jornal.DTOs
{
    public class JornalMaterialDto : DtoBase
    {
        public long MaterialId { get; set; }
        public MaterialDto Material { get; set; }
        public int CantidadUsado { get; set; }
        public JornalDto Jornal { get; set; }
        public long JornalId { get; set; }
    }
}
