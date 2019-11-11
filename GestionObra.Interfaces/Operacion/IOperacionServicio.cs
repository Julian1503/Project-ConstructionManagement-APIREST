using GestionObra.Interfaces.Operacion.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Interfaces.Operacion 
{
    public interface IOperacionServicio
    {
        Task Insertar(OperacionDto dto);
        Task<IEnumerable<OperacionDto>> ObtenerPorFiltro(string cadena);
        Task<OperacionDto> ObtenerPorId(long id);
        Task<IEnumerable<OperacionDto>> ObtenerPorBanco(long id);
        Task Borrar(long id);
        Task Modificar(OperacionDto dto);
        Task<IEnumerable<OperacionDto>> ObtenerPorTiempo(DateTime desde, DateTime hasta, long idCuentaCorriente);
        Task<IEnumerable<OperacionDto>> ObtenerTodos();
    }
}
