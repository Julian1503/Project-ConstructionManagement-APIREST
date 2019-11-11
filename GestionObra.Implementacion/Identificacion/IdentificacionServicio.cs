using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Identificacion;
using GestionObra.Interfaces.Identificacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.Identificacion
{
    public class IdentificacionServicio : IIdentificacion
    {
        private IRepositorio<Dominio.Entidades.Identificacion> _identificacionRepositorio;
        private IMapper _mapper;
        public IdentificacionServicio(IRepositorio<Dominio.Entidades.Identificacion> identificacionRepositorio)
        {
            _identificacionRepositorio = identificacionRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task<long> Insertar(IdentificacionDto dto)
        {
            using (var context = new DataContext())
            {
                var identificacion = _mapper.Map<Dominio.Entidades.Identificacion>(dto);
                await _identificacionRepositorio.Create(identificacion);
                return identificacion.Id;
            }
        }


        public async Task<IdentificacionDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var identificacion = await _identificacionRepositorio.GetById(id, null, true);
                if (identificacion == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<IdentificacionDto>(identificacion);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var identificacion = context.Identificaciones.FirstOrDefault(x => x.Id == id);
                await _identificacionRepositorio.Delete(identificacion);
            }
        }

        public async Task Modificar(IdentificacionDto dto)
        {
            using (var context = new DataContext())
            {
                var identificacion = context.Identificaciones.FirstOrDefault(x => x.Id == dto.Id);
                await _identificacionRepositorio.Update(identificacion);
            }
        }

        public async Task<IEnumerable<IdentificacionDto>> ObtenerTodos()
        {
            var identificacion = await _identificacionRepositorio.GetAll(null, null, true);
            return _mapper.Map<IEnumerable<IdentificacionDto>>(identificacion);
        }
    }
}
