using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.CuentaCorriente;
using GestionObra.Interfaces.CuentaCorriente.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace GestionObra.Implementacion.CuentaCorriente
{
    public class CuentaCorrienteServicio:ICuentaCorrienteRepositorio
    {
        private IRepositorio<Dominio.Entidades.CuentaCorriente> _cuentaCorrienteRepositorio;
        private IMapper _mapper;
        public CuentaCorrienteServicio(IRepositorio<Dominio.Entidades.CuentaCorriente> cuentaCorrienteRepositorio)
        {
            _cuentaCorrienteRepositorio = cuentaCorrienteRepositorio;
            var config = new MapperConfiguration(x=>x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(CuentaCorrienteDto dto)
        {
            using (var context = new DataContext())
            {
                var cuentacorriente = _mapper.Map<Dominio.Entidades.CuentaCorriente>(dto);
                await _cuentaCorrienteRepositorio.Create(cuentacorriente);
            }
        }

        public async Task<IEnumerable<CuentaCorrienteDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = await _cuentaCorrienteRepositorio.GetAll(null,x=>x.Include(y=>y.Comprobante).Include(y=>y.Banco).Include(y=>y.Cliente),false);
                return _mapper.Map<IEnumerable<CuentaCorrienteDto>>(cuentaCorriente);
            }
        }


        public async Task<CuentaCorrienteDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = await _cuentaCorrienteRepositorio.GetById(id, x => x.Include(y => y.Comprobante).Include(y => y.Banco).Include(y => y.Cliente),true);
                if (cuentaCorriente==null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CuentaCorrienteDto>(cuentaCorriente);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = context.CuentaCorrientes.FirstOrDefault(x => x.Id == id);
                if(cuentaCorriente!=null)
                await _cuentaCorrienteRepositorio.Delete(cuentaCorriente);
            }
        }

        public async Task Modificar(CuentaCorrienteDto dto)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = context.CuentaCorrientes.FirstOrDefault(x => x.Id == dto.Id);
                cuentaCorriente.ClienteId = dto.ClienteId;
                cuentaCorriente.ComprobanteId = dto.ComprobanteId;
                cuentaCorriente.BancoId = dto.BancoId;
                cuentaCorriente.FechaEmision = dto.FechaEmision;
                cuentaCorriente.FechaVencimiento = dto.FechaVencimiento;
                cuentaCorriente.TotalCobrado = dto.TotalCobrado;
                cuentaCorriente.TotalVendido = dto.TotalVendido;
                await _cuentaCorrienteRepositorio.Update(cuentaCorriente);
            }
        }

        public async Task<IEnumerable<CuentaCorrienteDto>> ObtenerConFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.CuentaCorriente, bool>> exp = x => true;
                exp = exp.And(x => x.Cliente.NombreFantasia.Contains(cadena));
                var cuentasCorrientes = await _cuentaCorrienteRepositorio.GetByFilter(exp,
                    x => x.OrderBy(y => y.FechaEmision), x => x.Include(y => y.Cliente), true);
                return _mapper.Map<IEnumerable<CuentaCorrienteDto>>(cuentasCorrientes);
            }
        }
    }
}
