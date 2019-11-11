using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Causa;
using GestionObra.Interfaces.Causa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.CausaFalta
{
    public class CausaFaltaServicio : ICausaFaltaServicio
    {
        private IRepositorio<Dominio.Entidades.CausaFalta> _causaFaltaRepositorio;
        private IMapper _mapper;
        public CausaFaltaServicio(IRepositorio<Dominio.Entidades.CausaFalta> causaFaltaRepositorio)
        {
            _causaFaltaRepositorio = causaFaltaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(CausaFaltaDto dto)
        {
            using (var context = new DataContext())
            {
                var causaFalta = _mapper.Map<Dominio.Entidades.CausaFalta>(dto);
                await _causaFaltaRepositorio.Create(causaFalta);
            }
        }

        public async Task<IEnumerable<CausaFaltaDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.CausaFalta, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var causaFaltas = await _causaFaltaRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion), null, true);
                return _mapper.Map<IEnumerable<CausaFaltaDto>>(causaFaltas);
            }
        }

        public async Task<CausaFaltaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var causaFalta = await _causaFaltaRepositorio.GetById(id, null, true);
                if (causaFalta == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CausaFaltaDto>(causaFalta);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var causaFalta = context.CausaFaltas.FirstOrDefault(x => x.Id == id);
                await _causaFaltaRepositorio.Delete(causaFalta);
            }
        }

        public async Task Modificar(CausaFaltaDto dto)
        {
            using (var context = new DataContext())
            {
                var causaFalta = context.CausaFaltas.FirstOrDefault(x => x.Id == dto.Id);
                causaFalta.Descripcion = dto.Descripcion;
                await _causaFaltaRepositorio.Update(causaFalta);
            }
        }

        public async Task<IEnumerable<CausaFaltaDto>> ObtenerTodos()
        {
            var causaFalta = await _causaFaltaRepositorio.GetAll(x => x.OrderBy(y => y.Descripcion), null, true);
            return _mapper.Map<IEnumerable<CausaFaltaDto>>(causaFalta);
        }
    }
}
