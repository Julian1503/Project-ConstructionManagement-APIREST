using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.ComprobanteSalida.DTOs;

namespace GestionObra.Interfaces.ComprobanteSalida
{
    public interface IComprobanteSalidaRepositorio
    {
        Task Insertar(ComprobanteSalidaDto dto);
        Task<IEnumerable<ComprobanteSalidaDto>> Obtener(string cadena);
        Task<ComprobanteSalidaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(ComprobanteSalidaDto dto);
    }
}
