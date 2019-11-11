using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Jornal.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionJornal.Implementacion.Jornal
{
    public class JornalServicio : IJornalServicio
    {
        private IRepositorio<GestionObra.Dominio.Entidades.Jornal> _jornalRepositorio;
        private IMapper _mapper;
        public JornalServicio(IRepositorio<GestionObra.Dominio.Entidades.Jornal> jornalRepositorio)
        {
            _jornalRepositorio = jornalRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(JornalDto dto)
        {
            using (var context = new DataContext())
            {
                var jornal = _mapper.Map<GestionObra.Dominio.Entidades.Jornal>(dto);
                await _jornalRepositorio.Create(jornal);
            }
        }

        public async Task<IEnumerable<JornalDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<GestionObra.Dominio.Entidades.Jornal, bool>> exp = x => true;
                exp = exp.And(x => x.Obra.Descripcion.Contains(cadena));
                var jornals = await _jornalRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroOrden), x => x.Include(y => y.Obra), true);
                return _mapper.Map<IEnumerable<JornalDto>>(jornals);
            }
        }

        public async Task<IEnumerable<JornalDto>> ObtenerPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<GestionObra.Dominio.Entidades.Jornal, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId==id);
                var jornals = await _jornalRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroOrden), x => x.Include(y => y.Obra), true);
                return _mapper.Map<IEnumerable<JornalDto>>(jornals);
            }
        }


        public async Task<JornalDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var jornal = await _jornalRepositorio.GetById(id, x => x.Include(y => y.Obra), true);
                if (jornal == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<JornalDto>(jornal);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var jornal = context.Jornales.FirstOrDefault(x => x.Id == id);
                await _jornalRepositorio.Delete(jornal);
            }
        }

        public async Task Modificar(JornalDto dto)
        {
            using (var context = new DataContext())
            {
                var jornal = context.Jornales.FirstOrDefault(x => x.Id == dto.Id);
                jornal.DiaJornal = dto.DiaJornal;
                jornal.Gasolina = dto.Gasolina;
                jornal.Otros = dto.Otros;
                jornal.Multas = dto.Multas;
                jornal.Repuestos = dto.Repuestos;
                jornal.NumeroOrden = dto.NumeroOrden;
                jornal.Viatico = dto.Viatico;
                await _jornalRepositorio.Update(jornal);
            }
        }

        public async Task<IEnumerable<JornalDto>> ObtenerTodos()
        {
            var jornal = await _jornalRepositorio.GetAll(x => x.OrderBy(y => y.NumeroOrden), x=>x.Include(y=>y.Obra), true);
            return _mapper.Map<IEnumerable<JornalDto>>(jornal);
        }
    }
}
