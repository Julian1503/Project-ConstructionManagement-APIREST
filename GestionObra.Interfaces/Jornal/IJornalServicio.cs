
using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Jornal
{
    public interface IJornalServicio
    {
        Task Insertar(JornalDto dto);
        Task<IEnumerable<JornalDto>> ObtenerPorFiltro(string cadena);
        Task<JornalDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(JornalDto dto);
        Task<IEnumerable<JornalDto>> ObtenerPorObra(long id);
        Task<IEnumerable<JornalDto>> ObtenerTodos();
    }
}
