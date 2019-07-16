using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.FormaPago.DTOs;

namespace GestionObra.Interfaces.FormaPago
{
    public interface IFormaPagoRepositorio
    {
        Task Insertar(FormaPagoDto dto);
        Task<IEnumerable<FormaPagoDto>> ObtenerTodos();
        Task<FormaPagoDto> ObtenerPorId(long id);
        Task Borrar(long id);
        Task Modificar(FormaPagoDto dto);
        Task<IEnumerable<FormaPagoDto>> ObtenerConFiltro(string cadena);
    }
}
