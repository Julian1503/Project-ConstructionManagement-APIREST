using GestionObra.Interfaces.SalarioMinimo.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.SalarioMinimo
{
    public interface ISalarioMinimoServicio
    {
        Task Insertar(SalarioMinimoDto dto);
        Task<IEnumerable<SalarioMinimoDto>> ObtenerPorFiltro(string cadena);
        Task<SalarioMinimoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(SalarioMinimoDto dto);
        Task<IEnumerable<SalarioMinimoDto>> ObtenerTodos();
    }
}
