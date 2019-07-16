using AutoMapper;
using GestionObra.Dominio;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Banco;
using GestionObra.Interfaces.Banco.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GestionObra.Dominio.Extension;

namespace GestionObra.Implementacion.Banco
{
    public class BancoServicio : IBancoRepositorio
    {
        private readonly IRepositorio<Dominio.Entidades.Banco> _bancoRepositorio;
        private IMapper _mapper;

        public BancoServicio(IRepositorio<Dominio.Entidades.Banco> bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
            var config = new MapperConfiguration(cfg=>cfg.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
               var bancoBorrar = context.Bancos.FirstOrDefault(x => x.Id == id);
               if(bancoBorrar!=null)
               await _bancoRepositorio.Delete(bancoBorrar);
            }
        }

        public async Task Insertar(BancoDto dto)
        {
            using (var context = new DataContext())
            {
                var nuevoBanco = _mapper.Map<Dominio.Entidades.Banco>(dto);
                await _bancoRepositorio.Create(nuevoBanco);
            }
        }

        public async Task Modificar(BancoDto dto)
        {
            using (var context = new DataContext())
            {
                var bancoModificar = context.Bancos.FirstOrDefault(x => x.Id == dto.Id);
                bancoModificar.Descripcion = dto.Descripcion;
               await _bancoRepositorio.Update(bancoModificar);
            }
        }
        public async Task<IEnumerable<BancoDto>> ObtenerConFiltro(string cadena)
        {
            Expression<Func<Dominio.Entidades.Banco, bool>> pred = x => true;
            pred = pred.And(x => x.Descripcion.Contains(cadena));

            var banco = await _bancoRepositorio.GetByFilter(pred, null, null);
            return _mapper.Map<IEnumerable<BancoDto>>(banco);
        }

        public async Task<BancoDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var banco = await _bancoRepositorio.GetById(id,enableTracking:true);
                if (banco == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<BancoDto>(banco);
                }
            }
        }

        public async Task<IEnumerable<BancoDto>> ObtenerTodos()
        {
            var banco = await _bancoRepositorio.GetAll(x => x.OrderBy(y => y.Descripcion), null, true);
            return _mapper.Map<IEnumerable<BancoDto>>(banco);
        }
    }
}
