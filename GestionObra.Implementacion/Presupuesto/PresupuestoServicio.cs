using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GestionObra.Constantes;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Presupuesto;
using GestionObra.Interfaces.Presupuesto.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Presupuesto
{
   public class PresupuestoServicio : IPresupuestoRepositorio
   {
       private IRepositorio<Dominio.Entidades.Presupuesto> _presupuestoRepositorio;
       private IMapper _mapper;

       public PresupuestoServicio(IRepositorio<Dominio.Entidades.Presupuesto> presupuestoRepositorio)
       {
           _presupuestoRepositorio = presupuestoRepositorio;
           var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
           _mapper = config.CreateMapper();
        }

        public async Task Insertar(PresupuestoDto dto)
        {
            using (var context = new DataContext())
            {
                var presupuesto = _mapper.Map<Dominio.Entidades.Presupuesto>(dto);
                await _presupuestoRepositorio.Create(presupuesto);
            }
        }

        public async Task CambioEstado(EstadoPresupuesto estado,long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == id);
                if (presupuesto != null)
                {
                    presupuesto.EstadoPresupuesto = estado;
                    await _presupuestoRepositorio.Update(presupuesto);
                }
            }
        }

        public async Task<IEnumerable<PresupuestoDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var presupuestos = await _presupuestoRepositorio.GetAll(
                    x => x.OrderBy(y => y.EstadoPresupuesto).OrderByDescending(y => y.Numero), x=>x.Include(y=>y.Gastos).Include(y => y.Empresa).Include(y => y.Obra).Include(y => y.Obra.Encargado), true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }

        public async Task<IEnumerable<PresupuestoDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoPresupuesto.ToString().Contains(cadena));
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.EstadoPresupuesto), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado), true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }
        public async Task<IEnumerable<PresupuestoDto>> ObtenerPorFecha(DateTime Desde,DateTime Hasta)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoPresupuesto==EstadoPresupuesto.Aprobado && x.FechaPresupuesto.Date>=Desde.Date && x.FechaPresupuesto.Date<=Hasta.Date);
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado), true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }
        public async Task<IEnumerable<PresupuestoDto>> ObtenerFinalizados()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoPresupuesto==EstadoPresupuesto.Aprobado);
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado).Include(y => y.Obra.Propietario), true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }

        public async Task<int> ObtenerSinCobrar()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.EstadoPresupuesto == EstadoPresupuesto.Aprobado && x.EstadoDeCobro==EstadoDeCobro.SinCobrar);
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado).Include(y => y.Obra.Propietario), true);
                return presupuestos.Count();
            }
        }
        public async Task<IEnumerable<PresupuestoDto>> ObtenerFacturados()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
                exp = exp.And(x => x.Facturado);
                var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                    x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado).Include(y => y.Obra.Propietario).Include(y => y.Empresa.CondicionIva), true);
                return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
            }
        }
        public async Task<PresupuestoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = await _presupuestoRepositorio.GetById(id, x => x.Include(y => y.Gastos).Include(y => y.Empresa).Include(y => y.Obra).Include(y => y.Obra.Encargado), true);
                if (presupuesto == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<PresupuestoDto>(presupuesto);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == id);
                await _presupuestoRepositorio.Delete(presupuesto);
            }
        }

        public async Task Modificar(PresupuestoDto dto)
        {
            using (var context = new DataContext())
            {
                var presupuesto = context.Presupuestos.FirstOrDefault(x => x.Id == dto.Id);
                presupuesto.FechaPresupuesto = dto.FechaPresupuesto;
                presupuesto.EstadoPresupuesto = dto.EstadoPresupuesto;
                presupuesto.Descripcion = dto.Descripcion;
                presupuesto.Titulo = dto.Titulo;
                presupuesto.EmpresaId = dto.EmpresaId;
                presupuesto.Numero = dto.Numero;
                presupuesto.ImprevistoPorcentual = dto.ImprevistoPorcentual;
                presupuesto.Beneficio = dto.Beneficio;
                presupuesto.PrecioCliente = dto.PrecioCliente;
                presupuesto.EstadoDeCobro = dto.EstadoDeCobro;
                presupuesto.Facturado = dto.Facturado;
                presupuesto.FechaFacturacion = dto.FechaFacturacion;
                presupuesto.Cae = dto.Cae;
                presupuesto.NumeroFacturacion = dto.NumeroFacturacion;
                presupuesto.Impuestos = dto.Impuestos;
                presupuesto.ObraId = dto.ObraId;
                presupuesto.Observacion = dto.Observacion;
                presupuesto.SubTotal = dto.SubTotal;
                presupuesto.Iva = dto.Iva;
                presupuesto.Retenciones = dto.Retenciones;
                presupuesto.Percepciones = dto.Percepciones;
                presupuesto.Descuento = dto.Descuento;
                presupuesto.Interes = dto.Interes;
                presupuesto.Cobrado= dto.Cobrado;
                await _presupuestoRepositorio.Update(presupuesto);
            }
        }

        public async Task<IEnumerable<PresupuestoDto>> ObtenerPorCliente(DateTime desde, DateTime hasta, long clienteId)
        {
            Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
            exp = exp.And(x => x.EstadoPresupuesto == EstadoPresupuesto.Aprobado && x.FechaPresupuesto.Date >= desde.Date && x.FechaPresupuesto.Date <= hasta.Date && x.EmpresaId==clienteId);
            var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado), true);
            return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
        }

        public async Task<IEnumerable<PresupuestoDto>> ObtenerFacturadosFecha(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.Presupuesto, bool>> exp = x => true;
            exp = exp.And(x => x.EstadoPresupuesto == EstadoPresupuesto.Aprobado && x.FechaPresupuesto.Date >= desde.Date && x.FechaPresupuesto.Date <= hasta.Date && x.Facturado);
            var presupuestos = await _presupuestoRepositorio.GetByFilter(exp,
                x => x.OrderByDescending(y => y.Numero), x => x.Include(y => y.Gastos).Include(y => y.Obra).Include(y => y.Empresa).Include(y => y.Obra.Encargado).Include(y=>y.Empresa.CondicionIva), true);
            return _mapper.Map<IEnumerable<PresupuestoDto>>(presupuestos);
        }
    }
}
