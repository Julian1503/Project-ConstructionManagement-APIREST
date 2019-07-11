using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.FormaPago;
using GestionObra.Interfaces.FormaPago.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.FormaPago
{
    public class FormaPagoServicio : IFormaPagoRepositorio
    {
        private IRepositorio<Dominio.Entidades.FormaPago> _formaPagoRepositorio;
        private IMapper _mapper;
        public FormaPagoServicio(IRepositorio<Dominio.Entidades.FormaPago> formaPagoRepositorio)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(FormaPagoDto dto)
        {
            using (var context = new DataContext())
            {
                var formaPago = _mapper.Map<Dominio.Entidades.FormaPago>(dto);
                await _formaPagoRepositorio.Create(formaPago);
            }
        }

        public async Task<IEnumerable<FormaPagoDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var formaPagos = await _formaPagoRepositorio.GetAll(x => x.OrderByDescending(y => y.ComprobanteId),
                    x => x.Include(y => y.Comprobante), true);
                return _mapper.Map<IEnumerable<FormaPagoDto>>(formaPagos);
            }
        }

        public async Task<FormaPagoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var formaPago = await _formaPagoRepositorio.GetById(id, x => x.Include(y => y.Comprobante), true);
                if (formaPago == null)
                {
                    return null;
                }
                else
                {
                return _mapper.Map<FormaPagoDto>(formaPago);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var formaPago = context.FormaPagos.FirstOrDefault(x => x.Id == id);
               await _formaPagoRepositorio.Delete(formaPago);
            }
        }

        public async Task Modificar(FormaPagoDto dto)
        {
            using (var context = new DataContext())
            {
                var formaPago = context.FormaPagos.FirstOrDefault(x => x.Id == dto.Id);
                formaPago = _mapper.Map<Dominio.Entidades.FormaPago>(dto);
                await _formaPagoRepositorio.Update(formaPago);
            }
        }
    }
}
