using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Rubro.DTOs;

namespace GestionObra.Interfaces.Rubro
{
    public interface IRubroRepositorio
    {
        Task Insertar(RubroDto dto);
        Task<IEnumerable<RubroDto>> ObtenerPorFiltro(string cadena);
        Task<IEnumerable<RubroDto>> ObtenerTodos();
        Task<RubroDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<IEnumerable<RubroDto>> ObtenerPorSalida();
        Task<IEnumerable<RubroDto>> ObtenerPorEntrada();
        Task Modificar(RubroDto dto);
    }
}
