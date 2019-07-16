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
using GestionObra.Interfaces.Tarea;
using GestionObra.Interfaces.Tarea.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Tarea
{
    public class TareaServicio : ITareaRepositorio
    {
        private IRepositorio<Dominio.Entidades.Tarea> _tareaRepositorio;
        private IMapper _mapper;
        public TareaServicio(IRepositorio<Dominio.Entidades.Tarea> tareaRepositorio)
        {
            _tareaRepositorio = tareaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(TareaDto dto)
        {
            using (var context = new DataContext())
            {
                var tarea = _mapper.Map<Dominio.Entidades.Tarea>(dto);
                await _tareaRepositorio.Create(tarea);
            }
        }

        public async Task<IEnumerable<TareaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Tarea, bool>> exp = x => true;
                exp = exp.And(x => x.DescripcionTarea.Descripcion.Contains(cadena));
                var tareas = await _tareaRepositorio.GetByFilter(exp,x=>x.OrderBy(y=>y.DescripcionTarea.Descripcion),x=>x.Include(y=>y.DescripcionTarea).Include(y=>y.Obra),true);
                return _mapper.Map<IEnumerable<TareaDto>>(tareas);
            }
        }

        public async Task<IEnumerable<TareaDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var tareas = await _tareaRepositorio.GetAll(x => x.OrderBy(y => y.NumeroOrden), null, true);
                return _mapper.Map<IEnumerable<TareaDto>>(tareas);
            }
        }

        public async Task<TareaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var tarea = _tareaRepositorio.GetById(id, x => x.Include(y => y.DescripcionTarea).Include(y => y.Obra),
                    true);
                if (tarea == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<TareaDto>(tarea);
                }

            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var tarea = context.Tareas.FirstOrDefault(x => x.Id == id);
                await _tareaRepositorio.Delete(tarea);
            }
        }

        public async Task Modificar(TareaDto dto)
        {
            using (var context = new DataContext())
            {
                var tarea = context.Tareas.FirstOrDefault(x => x.Id == dto.Id);
                tarea = _mapper.Map<Dominio.Entidades.Tarea>(dto);
                await _tareaRepositorio.Update(tarea);
            }
        }
    }
}
