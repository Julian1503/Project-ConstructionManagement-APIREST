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
using GestionObra.Interfaces.Empresa.DTOs;
using GestionObra.Interfaces.Obra;
using GestionObra.Interfaces.Obra.DTOs;
using GestionObra.Interfaces.Zona.DTOs;
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
                exp = exp.And(x => x.Descripcion.Contains(cadena) && x.EstadoObra!=0);
                var obras = await _obraRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.Descripcion),
                    x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
                return _mapper.Map<List<ObraDto>>(obras);
            }
        }

        public async Task<IEnumerable<ObraDto>> ObtenerEnProceso()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Obra, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoObra==Constantes.EstadoObra.EnProceso );
                var obras = await _obraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.Codigo),
                    x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
                return _mapper.Map<List<ObraDto>>(obras);
            }
        }
        public async Task<IEnumerable<ObraDto>> ObtenerPlanificando()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Obra, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoObra == Constantes.EstadoObra.Planificacion);
                var obras = await _obraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.Codigo),
                    x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
                return _mapper.Map<List<ObraDto>>(obras);
            }
        }

        public async Task<IEnumerable<ObraDto>> ObtenePendientes()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Obra, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoObra == Constantes.EstadoObra.Pendiente);
                var obras = await _obraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.Codigo),
                    x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
                return _mapper.Map<List<ObraDto>>(obras);
            }
        }

        public async Task<IEnumerable<ObraDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var obras = await _obraRepositorio.GetAll(x => x.OrderByDescending(y => y.Codigo),x=>x.Include(y=>y.Encargado).Include(y => y.Propietario).Include(y => y.Zona), true);

                return _mapper.Map<List<ObraDto>>(obras);
            }
        }

        public async Task<ObraDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var obra = await _obraRepositorio.GetById(id,
                    x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
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
                obra.EstadoObra = dto.EstadoObra;
                obra.Codigo = dto.Codigo;
                obra.Descripcion = dto.Descripcion;
                obra.FechaEstimadaInicio = dto.FechaEstimadaInicio;
                obra.Observacion = dto.Observacion;
                await _obraRepositorio.Update(obra);
            }
        }

        public async Task<int[]> ObtenerEnMarcha()
        {
            Expression<Func<Dominio.Entidades.Obra, bool>> xp = x => true;
            xp = xp.And(x => x.EstadoObra !=0);
            var obras = await _obraRepositorio.GetByFilter(xp, x => x.OrderByDescending(y => y.Codigo),
                x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
            Expression<Func<Dominio.Entidades.Obra, bool>> exp = x => true;
            exp = exp.And(x => x.EstadoObra == Constantes.EstadoObra.Finalizada);
            var obrasFinalizadas = await _obraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.Codigo),
                x => x.Include(y => y.Propietario).Include(y => y.Zona).Include(y => y.Encargado), true);
            return new int[] { obrasFinalizadas.Count(),obras.Count() };
        }
    }
}
