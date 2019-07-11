using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Caja.DTOs;

namespace GestionObra.Interfaces.Caja
{
    public interface ICajaRepositorio
    {
        Task AbrirCaja(CajaDto dto);
        Task CerrarCaja(CajaDto dto);
        bool EstadoCaja();
        CajaDto CajaAbierta();
    }
}
