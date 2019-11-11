using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.ComprobanteSalida.DTOs;

namespace GestionObra.Interfaces.ComprobanteSalida
{
    public interface IComprobanteSalidaRepositorio
    {
        Task<long> Insertar(ComprobanteSalidaDto dto);
        Task<IEnumerable<ComprobanteSalidaDto>> Obtener(string cadena);
        Task<ComprobanteSalidaDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task<decimal[]> ObtenerPorcentajes();
        Task Modificar(ComprobanteSalidaDto dto);
        Task<IEnumerable<ComprobanteSalidaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta);
        Task<IEnumerable<ComprobanteSalidaDto>> ObtenerPorRubro(DateTime desde, DateTime hasta,long rubroId);
        Task<IEnumerable<ComprobanteSalidaDto>> ObtenerPorSubRubro(DateTime desde, DateTime hasta, long subRubroId);
        Task<IEnumerable<ComprobanteSalidaDto>> ObtenerTodos();
        Task<long> ObtenerSiguienteId();
    }
}
