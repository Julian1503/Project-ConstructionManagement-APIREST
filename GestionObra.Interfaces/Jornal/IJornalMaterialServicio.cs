using GestionObra.Interfaces.Jornal.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Jornal
{
    public interface IJornalMaterialServicio
    {
        Task Insertar(JornalMaterialDto dto);
        Task<IEnumerable<JornalMaterialDto>> ObtenerPorFiltro(string cadena);
        Task<JornalMaterialDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(JornalMaterialDto dto);
        Task<IEnumerable<JornalMaterialDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<JornalMaterialDto>> ObtenerTodos();
        Task<IEnumerable<JornalMaterialDto>> ObtenerPorObra(long id);
        Task<IEnumerable<JornalMaterialDto>> ObtenerPorJornal(long id);
    }
}
