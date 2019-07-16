using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GestionObra.Interfaces.Stock.DTOs;

namespace GestionObra.Interfaces.Stock
{
    public interface IStockRepositorio
    {
        Task ActualizarStock(StockDto dto);
        Task DescontarStock(long materialId,int cantidad);
        Task<IEnumerable<StockDto>> ObtenerTodos();
        Task<StockDto> ObtenerUltimo(long materialId);
        Task<IEnumerable<StockDto>> ObtenerPorFiltro(string cadena);
        Task<StockDto> ObtenerPorId(long id);
        Task Borrar(long id);
    }
}
