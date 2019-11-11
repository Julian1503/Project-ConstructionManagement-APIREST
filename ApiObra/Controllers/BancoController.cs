using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Banco;
using GestionObra.Interfaces.Banco.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BancoController : ControllerBase
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        private IMapper _mapper;
        public BancoController(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
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
            var bancos = await _bancoRepositorio.ObtenerTodos();
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
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
            var bancos = await _bancoRepositorio.ObtenerConFiltro(cadena);

            if (bancos == null)
            {
                return NotFound();
            }
            return Ok(bancos);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bancos = await _bancoRepositorio.ObtenerPorId(id);
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _bancoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, BancoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banco = _mapper.Map<BancoDto>(model);
            banco.Id = id;
            await _bancoRepositorio.Modificar(banco);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(BancoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var banco = _mapper.Map<BancoDto>(model);
           var a = await _bancoRepositorio.Insertar(banco);
            return Ok(a);
        }
    }
}