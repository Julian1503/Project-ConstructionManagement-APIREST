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
using GestionObra.Interfaces.Zona;
using GestionObra.Interfaces.Zona.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Zona
{
    public class ZonaServicio : IZonaRepositorio
    {
        private IRepositorio<Dominio.Entidades.Zona> _zonaRepositorio;
        private IMapper _mapper;
        public ZonaServicio(IRepositorio<Dominio.Entidades.Zona> zonaRepositorio)
        {
            _zonaRepositorio = zonaRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task Insertar(ZonaDto dto)
        {
            using (var context = new DataContext())
            {
                var zona = _mapper.Map<Dominio.Entidades.Zona>(dto);
                await _zonaRepositorio.Create(zona);
            }
        }

        public async Task<IEnumerable<ZonaDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Zona, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var zonas = await _zonaRepositorio.GetByFilter(exp,x=>x.OrderByDescending(y=>y.Descripcion),null,true);
                return _mapper.Map<IEnumerable<ZonaDto>>(zonas);
            }
        }

        public async Task<ZonaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var zona = await _zonaRepositorio.GetById(id, null, true);
                if (zona == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ZonaDto>(zona);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var zona = context.Zonas.FirstOrDefault(x => x.Id == id);
                await _zonaRepositorio.Delete(zona);
            }
        }

        public async Task Modificar(ZonaDto dto)
        {
            using (var context = new DataContext())
            {
                var zona = context.Zonas.FirstOrDefault(x => x.Id == dto.Id);
                zona = _mapper.Map<Dominio.Entidades.Zona>(dto);
                await _zonaRepositorio.Delete(zona);
            }
        }
    }
}
