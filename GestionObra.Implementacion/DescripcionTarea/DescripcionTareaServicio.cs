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
using GestionObra.Interfaces.DescripcionTarea;
using GestionObra.Interfaces.DescripcionTarea.DTOs;

namespace GestionObra.Implementacion.DescripcionTarea
{
    public class DescripcionTareaServicio : IDescripcionTareaRepositorio
    {
        private IRepositorio<Dominio.Entidades.DescripcionTarea> _descripciontareaRepositorio;
        private IMapper _mapper;

        public DescripcionTareaServicio(IRepositorio<Dominio.Entidades.DescripcionTarea> descripciontareaRepositorio)
        {
            _descripciontareaRepositorio = descripciontareaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(DescripcionTareaDto dto)
        {
            using (var context = new DataContext())
            {
                var descripcionTarea = _mapper.Map<Dominio.Entidades.DescripcionTarea>(dto);
                await _descripciontareaRepositorio.Create(descripcionTarea);
            }
        }

        public async Task<IEnumerable<DescripcionTareaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.DescripcionTarea, bool>> expr = x => true;
                expr = expr.And(x => x.Descripcion.Contains(cadena));
                var tareas = await _descripciontareaRepositorio.GetByFilter(expr, x => x.OrderBy(y => y.Descripcion),
                    null, true);
                return _mapper.Map<IEnumerable<DescripcionTareaDto>>(tareas);
            }
        }

        public async Task<DescripcionTareaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var tareas = _descripciontareaRepositorio.GetById(id, null,true);
                if (tareas == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<DescripcionTareaDto>(tareas);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var tarea = context.DescripcionTareas.FirstOrDefault(x => x.Id == id);
                if(tarea!=null)
                await _descripciontareaRepositorio.Delete(tarea);
            }
        }

        public async Task Modificar(DescripcionTareaDto dto)
        {
            using (var context = new DataContext())
            {
                var tarea = context.DescripcionTareas.FirstOrDefault(x => x.Id == dto.Id);
                tarea.Descripcion = dto.Descripcion;
                await _descripciontareaRepositorio.Update(tarea);
            }
        }

        public  async Task<IEnumerable<DescripcionTareaDto>> ObtenerTodos()
        {
            var descripcionTareas = await _descripciontareaRepositorio.GetAll(x => x.OrderBy(y => y.Descripcion), null, true);
            return _mapper.Map<IEnumerable<DescripcionTareaDto>>(descripcionTareas);
        }
    }
}
