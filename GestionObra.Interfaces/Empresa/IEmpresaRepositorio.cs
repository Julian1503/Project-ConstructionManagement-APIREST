using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Empresa.DTOs;

namespace GestionObra.Interfaces.Empresa
{
    public interface IEmpresaRepositorio
    {
        Task Insertar(EmpresaDto dto);
        Task<IEnumerable<EmpresaDto>> Obtener(string cadena);
        Task<EmpresaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(EmpresaDto dto);
    }
}
