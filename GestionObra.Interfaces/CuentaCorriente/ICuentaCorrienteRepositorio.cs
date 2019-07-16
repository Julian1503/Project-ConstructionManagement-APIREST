using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.CuentaCorriente.DTOs;

namespace GestionObra.Interfaces.CuentaCorriente
{
    public interface ICuentaCorrienteRepositorio
    {
        Task Insertar(CuentaCorrienteDto dto);
        Task<IEnumerable<CuentaCorrienteDto>> ObtenerTodos();
        Task<CuentaCorrienteDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(CuentaCorrienteDto dto);
        Task<IEnumerable<CuentaCorrienteDto>> ObtenerConFiltro(string cadena);
    }
}
