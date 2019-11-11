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
using GestionObra.Interfaces.Usuario;
using GestionObra.Interfaces.Usuario.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GestionObra.Implementacion.Usuario
{
    public class UsuarioServicio : IUsuarioRepositorio
    {
        private IMapper _mapper;
        private IRepositorio<Dominio.Entidades.Usuario> _usuarioRepositorio;
        public UsuarioServicio(IRepositorio<Dominio.Entidades.Usuario> usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<MapperProfile.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        public async Task Insertar(UsuarioDto dto)
        {
            using (var context = new DataContext())
            {
                var usuario = _mapper.Map<Dominio.Entidades.Usuario>(dto);
                await _usuarioRepositorio.Create(usuario);
            }
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerPorFiltro(string cadena)
        {
            using (var context = new DataContext())
            {
                Expression<Func<Dominio.Entidades.Usuario, bool>> exp = x => true;
                exp = exp.And(x => x.UserName.Contains(cadena));
                var usuarios = await
                    _usuarioRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.UserName), x=>x.Include(y=>y.Empleado).Include(y => y.Identificacion), true);
                return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            }
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerTodos()
        {
            using (var context = new DataContext())
            {
                var usuarios = await _usuarioRepositorio.GetAll(x => x.OrderBy(y => y.UserName), x => x.Include(y => y.Empleado).Include(y=>y.Identificacion), true);
                return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
            }
        }

        public async Task<UsuarioDto> ObtenerPorId(long id)
        {
            using (var context = new DataContext())
            {
                var usuario = await _usuarioRepositorio.GetById(id, null, true);
                if (usuario == null)
                {
                    return null;
                }
                else
                {
                    return _mapper.Map<UsuarioDto>(usuario);

                }
            }
        }

        public async Task Borrar(long id)
        {
            using (var context = new DataContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == id);
                await _usuarioRepositorio.Delete(usuario);
            }
        }

        public async Task Modificar(UsuarioDto dto)
        {
            using (var context = new DataContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(x => x.Id == dto.Id);
                usuario = _mapper.Map<Dominio.Entidades.Usuario>(dto);
                await _usuarioRepositorio.Update(usuario);
            }
        }
        //LWulDKipEF01JtHlrk7YwLu0+5N+JV+BZHuAeVIQcC0=
        public async Task<UsuarioDto> Logearse(string usuario, string password)
        {
            Expression<Func<Dominio.Entidades.Usuario, bool>> exp = x => true;
            var pass = Encriptar.Desencriptar(password);
            exp = exp.And(x => x.UserName.Equals(usuario) && Encriptar.Desencriptar(x.Password).Equals(pass) );
            var usuarios = await
                _usuarioRepositorio.GetByFilter(exp, x => x.OrderBy(y => y.UserName), x => x.Include(y => y.Empleado).Include(y => y.Identificacion), true);
            if (usuarios.Count() == 1)
            {
                return _mapper.Map<UsuarioDto>(usuarios.First());
            }
            else
            {
                return null;
            }
          
        }
    }
}
