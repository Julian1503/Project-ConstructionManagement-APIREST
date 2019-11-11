using System;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.AsistenciaDiaria;
using GestionObra.Interfaces.AsistenciaDiaria.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AsistenciaDiariaController : ControllerBase
    {
        private readonly IAsistenciaDiariaServicio _asistenciaDiariaRepositorio;
        private IMapper _mapper;
        public AsistenciaDiariaController(IAsistenciaDiariaServicio asistenciaDiariaRepositorio)
        {
            _asistenciaDiariaRepositorio = asistenciaDiariaRepositorio;
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
            var asistenciaDiarias = await _asistenciaDiariaRepositorio.ObtenerTodos();
            if (asistenciaDiarias == null)
            {
                return NotFound();
            }

            return Ok(asistenciaDiarias);
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
            var asistenciaDiarias = await _asistenciaDiariaRepositorio.ObtenerPorFiltro(cadena);

            if (asistenciaDiarias == null)
            {
                return NotFound();
            }
            return Ok(asistenciaDiarias);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaDiarias = await _asistenciaDiariaRepositorio.ObtenerPorId(id);
            if (asistenciaDiarias == null)
            {
                return NotFound();
            }

            return Ok(asistenciaDiarias);
        }

        [HttpGet("GetByJornal/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByJornal(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaDiarias = await _asistenciaDiariaRepositorio.ObtenerPorJornal(id);
            if (asistenciaDiarias == null)
            {
                return NotFound();
            }

            return Ok(asistenciaDiarias);
        }
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _asistenciaDiariaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, AsistenciaDiariaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asistenciaDiaria = _mapper.Map<AsistenciaDiariaDto>(model);
            asistenciaDiaria.Id = id;
            await _asistenciaDiariaRepositorio.Modificar(asistenciaDiaria);
            return Ok(model);
        }
        [HttpGet]
        [Route("GetDesde/{desde:datetime}/{hasta:datetime}/{id:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetDesde(DateTime desde, DateTime hasta, long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratistas = await _asistenciaDiariaRepositorio.ObtenerPorDesde(desde, hasta, id);
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
        }
        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AsistenciaDiariaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaDiaria = _mapper.Map<AsistenciaDiariaDto>(model);
            await _asistenciaDiariaRepositorio.Insertar(asistenciaDiaria);
            return Ok(model);
        }
    }
}