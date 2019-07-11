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
using GestionObra.Interfaces.Movimiento;
using GestionObra.Interfaces.Movimiento.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Movimiento
{
   public class MovimientoServicio : IMovimientoRepositorio
   {
       private IRepositorio<Dominio.Entidades.Movimiento> _movimientoRepositorio;
       private IMapper _mapper;

       public MovimientoServicio(IRepositorio<Dominio.Entidades.Movimiento> movimientoRepositorio)
       {
           _movimientoRepositorio = movimientoRepositorio;
           var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
           _mapper = config.CreateMapper();
       }
        public async Task Insertar(MovimientoDto dto)
        {
            using (var context = new DataContext())
            {
                var movimiento = _mapper.Map<Dominio.Entidades.Movimiento>(dto);
                await _movimientoRepositorio.Create(movimiento);
            }
        }

        public async Task<IEnumerable<MovimientoDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var movimientos = await _movimientoRepositorio.GetAll(x => x.OrderByDescending(y => y.ComprobanteId),
                    x => x.Include(y => y.Usuario).Include(y => y.Caja).Include(y => y.Comprobante), true);
                return _mapper.Map<IEnumerable<MovimientoDto>>(movimientos);
            }
        }

        public async Task<MovimientoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var movimiento =  await _movimientoRepositorio.GetById(id,
                    x => x.Include(y => y.Usuario).Include(y => y.Caja).Include(y => y.Comprobante), true);
                if (movimiento == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<MovimientoDto>(movimiento);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var movimiento = context.Movimientos.FirstOrDefault(x => x.Id == id);
                await _movimientoRepositorio.Delete(movimiento);
            }
        }

        public async Task Modificar(MovimientoDto dto)
        {
            using (var context = new DataContext())
            {
                var movimiento = context.Movimientos.FirstOrDefault(x => x.Id == dto.Id);
                movimiento = _mapper.Map<Dominio.Entidades.Movimiento>(dto);
                await _movimientoRepositorio.Update(movimiento);
            }
        }
    }
}
