using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Usuario.DTOs;

namespace GestionObra.Interfaces.Usuario
{
    public interface IUsuarioRepositorio
    {
        Task Insertar(UsuarioDto dto);
        Task<IEnumerable<UsuarioDto>> Obtener(string cadena);
        Task<UsuarioDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(UsuarioDto dto);
    }
}
