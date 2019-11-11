using System;
using GestionObra.Interfaces.Banco.DTOs;
using GestionObra.Interfaces.Base;
using GestionObra.Interfaces.Empresa.DTOs;

namespace GestionObra.Interfaces.CuentaCorriente.DTOs
{
    public class CuentaCorrienteDto : DtoBase
    {
        public EmpresaDto Cliente { get; set; }
        public BancoDto Banco { get; set; }
        public long BancoId { get; set; }
        public long ClienteId { get; set; }
        public decimal MontoMaximo { get; set; }
    }
}
