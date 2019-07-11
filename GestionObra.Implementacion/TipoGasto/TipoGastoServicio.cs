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
using GestionObra.Interfaces.TipoGasto;
using GestionObra.Interfaces.TipoGasto.DTOs;

namespace GestionObra.Implementacion.TipoGasto
{
    public class TipoGastoServicio : ITipoGastoRepositorio
    {
        private IRepositorio<Dominio.Entidades.TipoGasto> _tipoGastoRepositorio;
        private IMapper _mapper;

        public TipoGastoServicio(IRepositorio<Dominio.Entidades.TipoGasto> tipoGastoRepositorio)
        {
            _tipoGastoRepositorio = tipoGastoRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(TipoGastoDto dto)
        {
            using (var context = new DataContext())
            {
                var tipoGasto = _mapper.Map<Dominio.Entidades.TipoGasto>(dto);
                await _tipoGastoRepositorio.Create(tipoGasto);
            }
        }

        public async Task<IEnumerable<TipoGastoDto>> Obtener(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.TipoGasto, bool>> exp = x => true;
                exp = exp.And(x => x.Descripcion.Contains(cadena));
                var tipoGastos = await 
                    _tipoGastoRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.Descripcion), null, true);
                return _mapper.Map<IEnumerable<TipoGastoDto>>(tipoGastos);
            }
        }

        public async Task<TipoGastoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var tipoGasto = await _tipoGastoRepositorio.GetById(id, null, true);
                if (tipoGasto == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<TipoGastoDto>(tipoGasto);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var tipoGasto = context.TipoGastos.FirstOrDefault(x => x.Id == id);
                await _tipoGastoRepositorio.Delete(tipoGasto);
            }
        }

        public async Task Modificar(TipoGastoDto dto)
        {
            using (var context = new DataContext())
            {
                var tipoGasto = context.TipoGastos.FirstOrDefault(x => x.Id == dto.Id);
                tipoGasto = _mapper.Map<Dominio.Entidades.TipoGasto>(tipoGasto);
                await _tipoGastoRepositorio.Update(tipoGasto);
            }
        }
    }
}
