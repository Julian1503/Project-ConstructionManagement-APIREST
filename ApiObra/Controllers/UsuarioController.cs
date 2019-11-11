using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Usuario;
using GestionObra.Interfaces.Usuario.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UsuarioController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio,IConfiguration configuration)
        {
            _configuration = configuration;
            _usuarioRepositorio = usuarioRepositorio;
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapper.MapperProfile>());
            _mapper = config.CreateMapper();
        }
        [HttpGet]
        [Route("GetAll")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarios = await _usuarioRepositorio.ObtenerTodos();
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet]
        [Route("GetByFilter/{cadena}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFilter(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarios = await _usuarioRepositorio.ObtenerPorFiltro(cadena);

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);

        }

         [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuarios = await _usuarioRepositorio.ObtenerPorId(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _usuarioRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _mapper.Map<UsuarioDto>(model);
            usuario.Id = id;
            await _usuarioRepositorio.Modificar(usuario);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(UsuarioModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var usuario = _mapper.Map<UsuarioDto>(model);
            usuario.Token = BuildToken(model);
            await _usuarioRepositorio.Insertar(usuario);
            usuario.Password = null;
            return Ok(usuario);
        }

        [AllowAnonymous]
        [HttpGet("Login/{usuario}/{password}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Login(string usuario,string password)
        {
           var result = await _usuarioRepositorio.Logearse(usuario, password);
            if (result!=null)
            {
                result.Token = BuildToken(new UsuarioModel
                {
                    UserName = usuario,
                    Password = password
                });
                result.Password = null;
                return Ok(result);
            }
            return Ok(false);
        }
        private string BuildToken(UsuarioModel userInfo)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Llave_super_secreta"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(6);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "Julien",
               audience: "Gonelec",
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}