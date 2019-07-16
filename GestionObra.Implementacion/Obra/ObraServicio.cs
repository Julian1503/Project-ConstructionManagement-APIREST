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
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Obra.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Obra
{
    public class ObraServicio : IObraRepositorio
    {
        private IRepositorio<Dominio.Entidades.Obra> _obraRepositorio;
        private IMapper _mapper;

        public ObraServicio(IRepositorio<Dominio.Entidades.Obra> obraRepositorio)
        {
            _obraRepositorio = obraRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(ObraDto dto)
        {
            using (var context = new DataContext())
            {
                var obra = _mapper.Map<Dominio.Entidades.Obra>(dto);
                await _obraRepositorio.Create(obra);
            }
        }

        public async Task<IEnumerable<ObraDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Obra, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var obras = await _obraRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion),
                    x => x.Include(y => y.Empresa).Include(y => y.Zona).Include(y => y.Encargado), true);
                return _mapper.Map<IEnumerable<ObraDto>>(obras);
            }
        }

        public async Task<IEnumerable<ObraDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var obras = await _obraRepositorio.GetAll(x => x.OrderBy(y => y.Codigo),null,true);
                return _mapper.Map<IEnumerable<ObraDto>>(obras);
            }
        }

        public async Task<ObraDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var obra = await _obraRepositorio.GetById(id,
                    x => x.Include(y => y.Empresa).Include(y => y.Zona).Include(y => y.Encargado), true);
                if (obra == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ObraDto>(obra);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var obra = context.Obras.FirstOrDefault(x => x.Id == id);
                await _obraRepositorio.Delete(obra);
            }
        }

        public async Task Modificar(ObraDto dto)
        {
            using (var context = new DataContext())
            {
                var obra = context.Obras.FirstOrDefault(x => x.Id == dto.Id);
                obra.ZonaId = dto.ZonaId;
                obra.EncargadoId = dto.EncargadoId;
                obra.PropietarioId = dto.PropietarioId;
                obra.Codigo = dto.Codigo;
                obra.Descripcion = dto.Descripcion;
                obra.FechaEstimadaInicio = dto.FechaEstimadaInicio;
                obra.Observiacion = dto.Observiacion;
                await _obraRepositorio.Update(obra);
            }
        }
    }
}
