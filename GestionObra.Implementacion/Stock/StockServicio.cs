using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
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
                    var stock = _mapper.Map<Dominio.Entidades.Stock>(dto);
                    await _stockRepositorio.Create(stock);
                    return;
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
                    x => x.OrderBy(y => y.FechaActualizacion).OrderBy(y => y.MaterialId),
                    x => x.Include(y => y.Usuario).Include(y => y.Material), true);
                return _mapper.Map<IEnumerable<StockDto>>(stocks);
            }
        }

        public async Task<StockDto> ObtenerUltimo(long materialId)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Stock, bool>> exp = x => true;
                exp = exp.And(y =>
                    context.Stocks.Where(x => x.MaterialId == materialId).Max(x => x.FechaActualizacion) ==
                    y.FechaActualizacion);
                var stock = (StockDto) await _stockRepositorio.GetByFilter(exp, null,x => x.Include(y => y.Material), true);
                return _mapper.Map<StockDto>(stock);

            }
        }

        public async Task<IEnumerable<StockDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Stock, bool>> exp = x => true;
                exp = exp.And(x => x.Material.Descripcion.Contains(cadena));
                var stocks = await _stockRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.FechaActualizacion),
                    x => x.Include(y => y.Material), true);
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
