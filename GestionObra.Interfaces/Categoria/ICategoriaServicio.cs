using GestionObra.Interfaces.Categoria.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Categoria
{
   public interface ICategoriaServicio
    {
        Task Insertar(CategoriaDto dto);
        Task<IEnumerable<CategoriaDto>> ObtenerPorFiltro(string cadena);
        Task<CategoriaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(CategoriaDto dto);
        Task<IEnumerable<CategoriaDto>> ObtenerTodos();
    }
}
