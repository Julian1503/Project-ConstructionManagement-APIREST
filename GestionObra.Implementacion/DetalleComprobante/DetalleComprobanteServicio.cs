using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.DetalleCaja;
using GestionObra.Interfaces.DetalleCaja.DTOs;
using GestionObra.Interfaces.DetalleComprobante;
using GestionObra.Interfaces.DetalleComprobante.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.DetalleComprobante
{
    public class DetalleComprobanteServicio : IDetalleComprobanteRepositorio
    {
        private IRepositorio<Dominio.Entidades.DetalleComprobante> _detalleComprobanteRepositorio;
        private IMapper _mapper;

        public DetalleComprobanteServicio(IRepositorio<Dominio.Entidades.DetalleComprobante> detalleComprobanteRepositorio)
        {
            _detalleComprobanteRepositorio = detalleComprobanteRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(DetalleComprobanteDto dto)
        {
            using (var context = new DataContext())
            {
                var detalleComprobante = _mapper.Map<Dominio.Entidades.DetalleComprobante>(dto);
                await _detalleComprobanteRepositorio.Create(detalleComprobante);
            }
        }

        public async Task<IEnumerable<DetalleComprobanteDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var detalleComprobante = await _detalleComprobanteRepositorio.GetAll(x => x.OrderByDescending(y => y.ComprobanteId),
                    x => x.Include(y => y.Comprobante), true);
                return _mapper.Map<IEnumerable<DetalleComprobanteDto>>(detalleComprobante);
            }
        }

        public async Task<DetalleComprobanteDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var detalleComprobante = _detalleComprobanteRepositorio.GetById(id, x => x.Include(y => y.Comprobante), true);
                if (detalleComprobante == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<DetalleComprobanteDto>(detalleComprobante);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var detalleComprobante = context.DetalleComprobantes.FirstOrDefault(x => x.Id == id);
                if(detalleComprobante!=null)
                await _detalleComprobanteRepositorio.Delete(detalleComprobante);
            }
        }

        public async Task Modificar(DetalleComprobanteDto dto)
        {
            using (var context = new DataContext())
            {
                var detalleComprobante = context.DetalleComprobantes.FirstOrDefault(x => x.Id == dto.Id);
                detalleComprobante = _mapper.Map<Dominio.Entidades.DetalleComprobante>(dto);
                await _detalleComprobanteRepositorio.Update(detalleComprobante);
            }
        }
    }
}
