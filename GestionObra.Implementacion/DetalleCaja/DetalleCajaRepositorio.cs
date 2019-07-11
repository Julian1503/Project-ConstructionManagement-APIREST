using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.DetalleCaja;
using GestionObra.Interfaces.DetalleCaja.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.DetalleCaja
{
    public class DetalleCajaRepositorio : IDetalleCajaRepositorio
    {
        private IRepositorio<Dominio.Entidades.DetalleCaja> _detalleCajaRepositorio;
        private IMapper _mapper;

        public DetalleCajaRepositorio(IRepositorio<Dominio.Entidades.DetalleCaja> detalleCajaRepositorio)
        {
            _detalleCajaRepositorio = detalleCajaRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(DetalleCajaDto dto)
        {
            using (var context = new DataContext())
            {
                var detalleCaja = _mapper.Map<Dominio.Entidades.DetalleCaja>(dto);
                await _detalleCajaRepositorio.Create(detalleCaja);
            }
        }

        public async Task<IEnumerable<DetalleCajaDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var detalleCaja = await _detalleCajaRepositorio.GetAll(x=>x.OrderByDescending(y=>y.CajaId),x=>x.Include(y=>y.Caja),true);
                return  _mapper.Map<IEnumerable<DetalleCajaDto>>(detalleCaja);
            }
        }


        public async Task<DetalleCajaDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var detalleCaja = await _detalleCajaRepositorio.GetById(id, x => x.Include(y => y.Caja), true);
                if (detalleCaja == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<DetalleCajaDto>(detalleCaja);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var detalleCaja = context.DetalleCajas.FirstOrDefault(x => x.Id == id);
                await _detalleCajaRepositorio.Delete(detalleCaja);
            }
        }

        public async Task Modificar(DetalleCajaDto dto)
        {
            using (var context = new DataContext())
            {
                var detalleCaja = context.DetalleCajas.FirstOrDefault(x => x.Id == dto.Id);
                detalleCaja = _mapper.Map<Dominio.Entidades.DetalleCaja>(dto);
                await _detalleCajaRepositorio.Update(detalleCaja);
            }
        }
    }
}
