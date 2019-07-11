using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Constantes;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Presupuesto;
using GestionObra.Interfaces.Presupuesto.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Presupuesto
{
   public class PresupuestoServicio : IPresupuestoRepositorio
   {
       private IRepositorio<Dominio.Entidades.Presupuesto> _presupuestoRepositorio;
       private IMapper _mapper;

       public PresupuestoServicio(IRepositorio<Dominio.Entidades.Presupuesto> presupuestoRepositorio)
       {
           _presupuestoRepositorio = presupuestoRepositorio;
           var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
           _mapper = config.CreateMapper();
        }

        public async Task Insertar(PresupuestoDto dto)
        {
            using (var context = new DataContext())
            {
                var presupuesto = _mapper.Map<Dominio.Entidades.Presupuesto>(dto);
                await _presupuestoRepositorio.Create(presupuesto);
            }
        }

        public async Task CambioEstado(EstadoPresupuesto estado,long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == id);
                if (presupuesto != null)
                {
                    presupuesto.EstadoPresupuesto = estado;
                    await _presupuestoRepositorio.Update(presupuesto);
                }
            }
        }

        public async Task<IEnumerable<PresupuestoDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoPresupuesto.ToString().Contains(cadena));
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.EstadoPresupuesto), null, true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }

        public async Task<PresupuestoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = await _presupuestoRepositorio.GetById(id, null, true);
                if (presupuesto == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<PresupuestoDto>(presupuesto);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == id);
                await _presupuestoRepositorio.Delete(presupuesto);
            }
        }

        public async Task Modificar(PresupuestoDto dto)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == dto.Id);
                presupuesto = _mapper.Map<Dominio.Entidades.Presupuesto>(dto);
                await _presupuestoRepositorio.Update(presupuesto);
            }
        }
    }
}
