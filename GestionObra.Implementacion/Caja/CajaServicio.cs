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
using GestionObra.Interfaces.Caja;
using GestionObra.Interfaces.Caja.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Caja
{
    public class CajaServicio :ICajaRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Caja> _cajaRepositorio;
        private IMapper _mapper;
        public CajaServicio(IRepositorio<Dominio.Entidades.Caja> cajaRepositorio)
        {
            _cajaRepositorio = cajaRepositorio;
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }


        public async Task AbrirCaja(CajaDto dto)
        {
            using (var context = new DataContext())
            {
                //SI ES QUE EL MONTO CIERRE , MONTO APERTURA SON IGUALES
                //Y EL MONTO = 0 SIGNIFICA QUE TENGO UNA CAJA ABIERTA 
                if (context.Cajas.Any
                    (x => x.FechaCierre==null && x.UsuarioCierreId==null)) throw new Exception("No puede haber dos cajas abiertas");
                var caja = _mapper.Map<Dominio.Entidades.Caja>(dto);
                    await _cajaRepositorio.Create(caja);
                
            }
        }
        public async Task<IEnumerable<CajaDto>> ObtenerPorDesde(DateTime desde, DateTime hasta)
        {
            Expression<Func<Dominio.Entidades.Caja, bool>> exp = x => true;
            exp = exp.And(x => x.FechaApertura >= desde && x.FechaApertura <= hasta);
            var asistenciaContratistas = await _cajaRepositorio.GetByFilter(exp, x => x.OrderByDescending(y => y.FechaApertura), null, true);
            return _mapper.Map<IEnumerable<CajaDto>>(asistenciaContratistas);
        }
        public async Task CerrarCaja(CajaDto dto)
        {
            using (var context = new DataContext())
            {
                var caja = context.Cajas.FirstOrDefault(x => x.UsuarioCierreId == null );
                caja.UsuarioCierreId = dto.UsuarioCierreId;
                caja.FechaCierre = dto.FechaCierre;
                caja.MontoCierre = dto.MontoCierre;
                caja.MontoSistema = dto.MontoSistema; 
                caja.Diferencia = dto.Diferencia;
                await _cajaRepositorio.Update(caja);
            }
        }

        public bool EstadoCaja()
        {
            using (var context = new DataContext())
            {
                if (!context.Cajas.Any())
                {
                    return false;
                }
                
                return context.Cajas.Any(x =>  x.UsuarioCierreId == null);
            }
        }

        public CajaDto CajaAbierta()
        {
            using (var context = new DataContext())
            {
                if (!context.Cajas.Any())
                {
                    return null;
                }
                var caja = context.Cajas.FirstOrDefault(x => x.UsuarioCierreId == null);
                if (caja == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<CajaDto>(caja);
                }
            }
        }
    }
}
