using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.SalidaMaterial;
using GestionObra.Interfaces.SalidaMaterial.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.SalidaMaterial
{
    public class SalidaMaterialServicio : ISalidaMaterialRepositorio
    {
        private IRepositorio<Dominio.Entidades.SalidaMaterial> _salidaMaterialRepositorio;
        private IMapper _mapper;
        public SalidaMaterialServicio(IRepositorio<Dominio.Entidades.SalidaMaterial> salidaMaterialRepositorio)
        {
            _salidaMaterialRepositorio = salidaMaterialRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(SalidaMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var salidaMaterial = _mapper.Map<Dominio.Entidades.SalidaMaterial>(dto);
                await _salidaMaterialRepositorio.Create(salidaMaterial);
            }
        }

        public async Task<IEnumerable<SalidaMaterialDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.SalidaMaterial, bool>> exp = x => true;
                exp = exp.And(x=>x.Material.Descripcion.Contains(cadena));
                var salidaMaterial = await _salidaMaterialRepositorio.GetByFilter(exp,
                    x => x.OrderBy(y => y.FechaEgreso), x => x.Include(y => y.Material)
                    .Include(y => y.DeObra).Include(y => y.ParaObra)
                    .Include(y => y.Responsable), true);
                return _mapper.Map<IEnumerable<SalidaMaterialDto>>(salidaMaterial);
            }
        }

        public async Task<IEnumerable<SalidaMaterialDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var salidaMateriales = await _salidaMaterialRepositorio.GetAll(x => x.OrderBy(y => y.FechaEgreso),
                    x => x.Include(y => y.Material).Include(y => y.DeObra).Include(y => y.ParaObra)
                        .Include(y => y.Responsable), true);
                return _mapper.Map<IEnumerable<SalidaMaterialDto>>(salidaMateriales);
            }
        }

        public async Task<SalidaMaterialDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var salidaMaterial = await _salidaMaterialRepositorio.GetById(id, x => x.Include(y => y.Material)
                    .Include(y => y.DeObra).Include(y => y.ParaObra)
                    .Include(y => y.Responsable), true);
                return _mapper.Map<SalidaMaterialDto>(salidaMaterial);
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var salidaMaterial = context.SalidaMateriales.FirstOrDefault(x => x.Id == id);
                await _salidaMaterialRepositorio.Delete(salidaMaterial);
            }
        }

        public async Task Modificar(SalidaMaterialDto dto)
        {
            using (var context = new DataContext())
            {
                var salidaMaterial = context.SalidaMateriales.FirstOrDefault(x => x.Id == dto.Id);
                salidaMaterial.Cantidad = dto.Cantidad;
                salidaMaterial.MaterialId = dto.MaterialId;
                salidaMaterial.DeObraId = dto.DeObraId;
                salidaMaterial.ResponsableId = dto.ResponsableId;
                salidaMaterial.FechaEgreso = dto.FechaEgreso;
                salidaMaterial.ParaObraId = dto.ParaObraId;
                await _salidaMaterialRepositorio.Update(salidaMaterial);
            }
        }

        public async Task<IEnumerable<SalidaMaterialDto>> ObtenerPorObra(int id)
        {
            Expression<Func<Dominio.Entidades.SalidaMaterial, bool>> exp = x => true;
            exp = exp.And(x => x.DeObraId == id);
            var salidaMaterial = await _salidaMaterialRepositorio.GetByFilter(exp,
                       x => x.OrderBy(y => y.FechaEgreso), x => x.Include(y => y.Material).Include(y=>y.DeObra).Include(y => y.ParaObra).Include(y => y.Responsable), true);
            return _mapper.Map<IEnumerable<SalidaMaterialDto>>(salidaMaterial);
        }
    }
}
