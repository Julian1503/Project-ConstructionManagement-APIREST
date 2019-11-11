using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Rubro.DTOs;
using GestionObra.Interfaces.SubRubro;
using GestionObra.Interfaces.SubRubro.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.SubRubro
{
    public class SubRubroServicio : ISubRubroServicio
    {
        private IRepositorio<Dominio.Entidades.SubRubro> _rubroRepositorio;
        private IMapper _mapper;

        public SubRubroServicio(IRepositorio<Dominio.Entidades.SubRubro> rubroRepositorio)
        {
            _rubroRepositorio = rubroRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(SubRubroDto dto)
        {
            using (var context = new DataContext())
            {
                var subRubro = _mapper.Map<Dominio.Entidades.SubRubro>(dto);
                subRubro.Rubro = null;
                await _rubroRepositorio.Create(subRubro);
            }
        }
        public async Task<IEnumerable<SubRubroDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var subRubros = await _rubroRepositorio.GetAll(
                    x => x.OrderBy(y => y.Codigo), x => x.Include(y=>y.Rubro), true);
                return _mapper.Map<IEnumerable<SubRubroDto>>(subRubros);
            }
        }
        public async Task<IEnumerable<SubRubroDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SubRubro, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var subRubro = await _rubroRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Codigo), x => x.Include(y => y.Rubro), true);
                return _mapper.Map<IEnumerable<SubRubroDto>>(subRubro);
            }
        }
        public async Task<IEnumerable<SubRubroDto>> ObtenerPorRubroId(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SubRubro, bool>> exp = x => true;
                exp = exp.And(x => x.RubroId==id);
                var subRubro = await _rubroRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Codigo), x => x.Include(y => y.Rubro), true);
                return _mapper.Map<IEnumerable<SubRubroDto>>(subRubro);
            }
        }
        public async Task<IEnumerable<SubRubroDto>> ObtenerEntradas()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SubRubro, bool>> exp = x => true;
                exp = exp.And(x => x.Rubro.TipoRubro==Constantes.TipoRubro.Ingreso);
                var subRubro = await _rubroRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Codigo), x => x.Include(y => y.Rubro), true);
                return _mapper.Map<IEnumerable<SubRubroDto>>(subRubro);
            }
        }
        public async Task<IEnumerable<SubRubroDto>> ObtenerSalidas()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SubRubro, bool>> exp = x => true;
                exp = exp.And(x => x.Rubro.TipoRubro == Constantes.TipoRubro.Egreso);
                var subRubro = await _rubroRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Codigo), x => x.Include(y => y.Rubro), true);
                return _mapper.Map<IEnumerable<SubRubroDto>>(subRubro);
            }
        }

        public async Task<SubRubroDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var subRubro = await _rubroRepositorio.GetById(id, x=> x.Include(y => y.Rubro), true);
                if (subRubro == null)
                {
                    return null;
                }
                else
                {
                return _mapper.Map<SubRubroDto>(subRubro);

                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var subRubro = context.SubRubros.FirstOrDefault(x => x.Id == id);
                await _rubroRepositorio.Delete(subRubro);
            }
        }

        public async Task Modificar(SubRubroDto dto)
        {
            using (var context = new DataContext())
            {
                var subRubro = context.SubRubros.FirstOrDefault(x => x.Id == dto.Id);
                subRubro.Descripcion = dto.Descripcion;
                subRubro.RubroId = dto.RubroId;
                subRubro.Codigo = dto.Codigo;
                await _rubroRepositorio.Update(subRubro);
            }
        }
    }
}
