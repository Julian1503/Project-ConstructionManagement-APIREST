using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Dominio.Extension;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.ComprobanteCompra;
using GestionObra.Interfaces.ComprobanteCompra.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionObra.Implementacion.ComprobanteCompra
{
    public class ComprobanteCompraServicio : IComprobanteCompraServicio
    {
        private IRepositorio<Dominio.Entidades.ComprobanteCompra> _comprobanteCompraRepositorio;
        private IMapper _mapper;
        public ComprobanteCompraServicio(IRepositorio<Dominio.Entidades.ComprobanteCompra> comprobanteCompraRepositorio)
        {
            _comprobanteCompraRepositorio = comprobanteCompraRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }

        public async Task<long> ObtenerSiguienteId()
        {
            using (var context = new DataContext())
            {
                var comprobantes = await _comprobanteCompraRepositorio.GetAll(x => x.OrderBy(y => y.Id), null, true);
                if (comprobantes.Count() == 0)
                {
                    return 1;
                }
                return comprobantes.Max(x => x.Id) + 1;
            }
        }

        public async  Task<int> ObtenerUltimo()
        {
            using (var context = new DataContext())
            {
                var comprobanteCompra = await _comprobanteCompraRepositorio.GetAll(x => x.OrderByDescending(y => y.NumeroCompra), null, true);
                if(comprobanteCompra.Count()>0)
                {
                    return comprobanteCompra.Max(x => x.NumeroCompra) + 1;
                }
                return 1;
            }
        }
        public async Task Insertar(ComprobanteCompraDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteCompra = _mapper.Map<Dominio.Entidades.ComprobanteCompra>(dto);
                await _comprobanteCompraRepositorio.Create(comprobanteCompra);
            }
        }

        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
                exp = exp.And(x => x.Obra.Descripcion.Contains(cadena));
                var comprobanteCompras = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.NumeroCompra), null, true);
                return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(comprobanteCompras);
            }
        }
        public async Task<decimal> ObtenerOficina()
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
                exp = exp.And(x => x.Obra.Id==1);
                var comprobanteCompras = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.NumeroCompra), null, true);
                return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(comprobanteCompras).Sum(x=>x.Total);
            }
        }
        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorObra(long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
                exp = exp.And(x => x.ObraId==id);
                var comprobanteCompras = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.NumeroCompra), x=>x.Include(y=>y.Proveedor).Include(y=>y.Obra), true);
                return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(comprobanteCompras);
            }
        }

        public async Task<ComprobanteCompraDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteCompra = await _comprobanteCompraRepositorio.GetById(id, null, true);
                if (comprobanteCompra == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<ComprobanteCompraDto>(comprobanteCompra);
                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var comprobanteCompra = context.ComprobanteCompras.FirstOrDefault(x => x.Id == id);
                await _comprobanteCompraRepositorio.Delete(comprobanteCompra);
            }
        }

        public async Task Modificar(ComprobanteCompraDto dto)
        {
            using (var context = new DataContext())
            {
                var comprobanteCompra = context.ComprobanteCompras.FirstOrDefault(x => x.Id == dto.Id);
                comprobanteCompra.Descripcion = dto.Descripcion;
                comprobanteCompra.NumeroCompra = dto.NumeroCompra;
                comprobanteCompra.Monto = dto.Monto;
                comprobanteCompra.Iva = dto.Iva;
                comprobanteCompra.Pagando = dto.Pagando;
                comprobanteCompra.ObraId = dto.ObraId;
                comprobanteCompra.Percepciones = dto.Percepciones;
                comprobanteCompra.ProveedorId = dto.ProveedorId;
                comprobanteCompra.TipoPago = dto.TipoPago;
                comprobanteCompra.Recargos = dto.Recargos;
                comprobanteCompra.Retenciones = dto.Retenciones;
                comprobanteCompra.Fecha = dto.Fecha;
                comprobanteCompra.Pagado = dto.Pagado;
                comprobanteCompra.EstadoCompra = dto.EstadoCompra;
                await _comprobanteCompraRepositorio.Update(comprobanteCompra);
            }
        }

        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta);
            var asistenciaContratistas = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroCompra), x => x.Include(y => y.Proveedor).ThenInclude(y=>y.CondicionIva).Include(y => y.Obra), true);
            return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorObraFecha(DateTime desde, DateTime hasta, long id)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
                exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.ObraId == id);
                var comprobanteCompras = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.NumeroCompra), x => x.Include(y => y.Proveedor).Include(y => y.Obra), true);
                return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(comprobanteCompras);
            }
        }


        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorProveedor(DateTime desde, DateTime hasta,long id)
        {
            Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.ProveedorId==id);
            var asistenciaContratistas = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroCompra), x => x.Include(y => y.Proveedor).Include(y => y.Obra), true);
            return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerPorCuit(DateTime desde, DateTime hasta,string cuit)
        {
            Expression<Func<Dominio.Entidades.ComprobanteCompra, bool>> exp = x => true;
            exp = exp.And(x => x.Fecha.Date >= desde && x.Fecha.Date <= hasta && x.Cuit.Contains(cuit));
            var asistenciaContratistas = await _comprobanteCompraRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.NumeroCompra), x => x.Include(y => y.Proveedor).Include(y => y.Obra), true);
            return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(asistenciaContratistas);
        }

        public async Task<IEnumerable<ComprobanteCompraDto>> ObtenerTodos()
        {
            var comprobanteCompra = await _comprobanteCompraRepositorio.GetAll(x => x.OrderByDescending(y => y.NumeroCompra), x=>x.Include(y => y.Obra).Include(y=>y.Proveedor).ThenInclude(y=>y.CondicionIva), true);
            return _mapper.Map<IEnumerable<ComprobanteCompraDto>>(comprobanteCompra);
        }
    }
}
