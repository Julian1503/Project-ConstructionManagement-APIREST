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
using GestionObra.Interfaces.CondicionIva;
using GestionObra.Interfaces.CondicionIva.DTOs;

namespace GestionObra.Implementacion.CondicionIva
{
    public class CondicionIvaServicio : ICondicionIvaRepositorio
    {
        private IRepositorio<Dominio.Entidades.CondicionIva> _condicionIvaRepositorio;
        private IMapper _mapper;
        public CondicionIvaServicio(IRepositorio<Dominio.Entidades.CondicionIva> condicionIvaRepositorio)
        {
            _condicionIvaRepositorio = condicionIvaRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(CondicionIvaDto dto)
        {
            using (var context = new DataContext())
            {
                var condicionIva = _mapper.Map<Dominio.Entidades.CondicionIva>(dto);
               await _condicionIvaRepositorio.Create(condicionIva);
            }
        }

        public async Task<IEnumerable<CondicionIvaDto>> Obtener(string cadena)
        {
            Expression<Func<Dominio.Entidades.CondicionIva, bool>> exp = x => true;
            exp = exp.And(x => x.Descripcion.Contains(cadena));
            var condicionIva = await _condicionIvaRepositorio.GetByFilter(exp, null, null,true);
            return _mapper.Map<IEnumerable<CondicionIvaDto>>(condicionIva);
        }

        public async Task<CondicionIvaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var condicionIva = await _condicionIvaRepositorio.GetById(id,enableTracking:true);
                if (condicionIva == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CondicionIvaDto>(condicionIva);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var condicionIva = context.CondicionIvas.FirstOrDefault(x => x.Id == id);
                await _condicionIvaRepositorio.Delete(condicionIva);
            }
        }

        public async Task Modificar(CondicionIvaDto dto)
        {
            using (var context = new DataContext())
            {
                var condicionIva = context.CondicionIvas.FirstOrDefault(x => x.Id == dto.Id);
                condicionIva = _mapper.Map<Dominio.Entidades.CondicionIva>(dto);
                await _condicionIvaRepositorio.Update(condicionIva);
            }
        }
    }
}
