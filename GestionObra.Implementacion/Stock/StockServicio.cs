using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Stock;
using GestionObra.Interfaces.Stock.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Stock
{
    public class StockServicio : IStockRepositorio
    {
        private IRepositorio<Dominio.Entidades.Stock> _stockRepositorio;
        private IMapper _mapper;
        public StockServicio(IRepositorio<Dominio.Entidades.Stock> stockRepositorio)
        {
            _stockRepositorio = stockRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task ActualizarStock(StockDto dto)
        {
            using (var context = new DataContext())
            {
                if (!context.Stocks.Any(x => x.MaterialId == dto.MaterialId))
                {
                    var stock = _mapper.Map<Dominio.Entidades.Stock>(dto);
                    await _stockRepositorio.Create(stock);
                    return;
                }
                else
                {
                    var stock = context.Stocks.FirstOrDefault(x => x.Id == dto.Id);
                    stock = _mapper.Map<Dominio.Entidades.Stock>(dto);
                    await _stockRepositorio.Update(stock);
                }
            }
        }

        public async Task DescontarStock(long materialId, int cantidad)
        {
            using (var context= new DataContext())
            {
                if(context.Stocks.Any(x => x.MaterialId == materialId))
                {
                    var stock = context.Stocks.FirstOrDefault(x => x.MaterialId == materialId);
                    stock.StockActual -= cantidad;
                    await _stockRepositorio.Update(stock);
                }
            }
        }

        public async Task<IEnumerable<StockDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var stocks = await _stockRepositorio.GetAll(
                    x => x.OrderByDescending(y => y.FechaActualizacion).OrderByDescending(y => y.MaterialId),
                    x => x.Include(y => y.Usuario).Include(y => y.Material), true);
                return _mapper.Map<IEnumerable<StockDto>>(stocks);
            }
        }

        public async Task<StockDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var stock = await _stockRepositorio.GetById(id,
                    x => x.Include(y => y.Usuario).Include(y => y.Material), true);
                return _mapper.Map<StockDto>(stock);
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var stock = context.Stocks.FirstOrDefault(x => x.Id == id);
                await _stockRepositorio.Delete(stock);
            }
        }
    }
}
