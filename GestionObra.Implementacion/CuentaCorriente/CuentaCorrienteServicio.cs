using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.CuentaCorriente;
using GestionObra.Interfaces.CuentaCorriente.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.CuentaCorriente
{
    public class CuentaCorrienteServicio : ICuentaCorrienteRepositorio
    {
        private IRepositorio<Dominio.Entidades.CuentaCorriente> _cuentaCorrienteRepositorio;
        private IMapper _mapper;
        public CuentaCorrienteServicio(IRepositorio<Dominio.Entidades.CuentaCorriente> cuentaCorrienteRepositorio)
        {
            _cuentaCorrienteRepositorio = cuentaCorrienteRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
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
                var cuentaCorriente = await _cuentaCorrienteRepositorio.GetAll(null, x => x.Include(y => y.Banco), false);
                return _mapper.Map<IEnumerable<CuentaCorrienteDto>>(cuentaCorriente);
            }
        }


        public async Task<CuentaCorrienteDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = await _cuentaCorrienteRepositorio.GetById(id, x => x.Include(y => y.Banco), true);
                if (cuentaCorriente == null)
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
                if (cuentaCorriente != null)
                    await _cuentaCorrienteRepositorio.Delete(cuentaCorriente);
            }
        }

        public async Task Modificar(CuentaCorrienteDto dto)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = context.CuentaCorrientes.FirstOrDefault(x => x.Id == dto.Id);
                cuentaCorriente.MontoMaximo = dto.MontoMaximo;
                cuentaCorriente.BancoId = dto.BancoId;
                await _cuentaCorrienteRepositorio.Update(cuentaCorriente);
            }
        }

        public async Task<IEnumerable<CuentaCorrienteDto>> ObtenerConFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.CuentaCorriente, bool>> exp = x => true;
                exp = exp.And(x => x.Banco.RazonSocial.Contains(cadena));
                var cuentasCorrientes = await _cuentaCorrienteRepositorio.GetByFilter(exp,
                    x => x.OrderBy(y => y.Banco.RazonSocial), x => x.Include(y => y.Banco), true);
                return _mapper.Map<IEnumerable<CuentaCorrienteDto>>(cuentasCorrientes);
            }
        }

        public async Task<CuentaCorrienteDto> ObtenerPorBanco(int id)
        {
            using (var context = new DataContext())
            {
                var cuentaCorriente = await _cuentaCorrienteRepositorio.GetAll(null, x => x.Include(y => y.Banco), false);
                var cuenta = cuentaCorriente.FirstOrDefault(x => x.BancoId == id);
                return _mapper.Map<CuentaCorrienteDto>(cuenta);
            }
        }
    }
}
