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
using GestionObra.Interfaces.Gasto;
using GestionObra.Interfaces.Gasto.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Gasto
{
   public class GastoServicio : IGastoRepositorio
   {
       private IRepositorio<Dominio.Entidades.Gasto> _gastoRepositorio;
       private IMapper _mapper;
        public GastoServicio(IRepositorio<Dominio.Entidades.Gasto> gastoRepositorio)
        {
            _gastoRepositorio = gastoRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(GastoDto dto)
        {
            using (var context = new DataContext())
            {
                var gasto = _mapper.Map<Dominio.Entidades.Gasto>(dto);
                await _gastoRepositorio.Create(gasto);
            }
        }

        public async Task<IEnumerable<GastoDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var gastos = await _gastoRepositorio.GetAll(x => x.OrderBy(y => y.PresupuestoId),
                    x => x.Include(y => y.Presupuesto).Include(y => y.TipoGasto), true);
                return _mapper.Map<IEnumerable<GastoDto>>(gastos);
            }
        }


        public async Task<GastoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var gasto = await _gastoRepositorio.GetById(id, x => x.Include(y => y.Presupuesto).Include(y => y.TipoGasto),
                    true);
                if (gasto == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<GastoDto>(gasto);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var gasto = context.Gastos.FirstOrDefault(x => x.Id == id);
                await _gastoRepositorio.Delete(gasto);
            }
        }

        public async Task Modificar(GastoDto dto)
        {
            using (var context = new DataContext())
            {
                var gasto = context.Gastos.FirstOrDefault(x => x.Id == dto.Id);
                gasto.Monto = dto.Monto;
                gasto.PresupuestoId = dto.PresupuestoId;
                gasto.TipoGastoId = dto.TipoGastoId;
                await _gastoRepositorio.Update(gasto);
            }
        }

        public async Task<IEnumerable<GastoDto>> ObtenerConFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Gasto, bool>> exp = x => true;
                exp = exp.And(x => x.PresupuestoId.ToString().Equals(cadena));
                var formaPago =
                    await _gastoRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.PresupuestoId), null, true);
                return _mapper.Map<IEnumerable<GastoDto>>(formaPago);
            }
        }
   }
}
