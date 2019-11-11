using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.AsistenciaContratista;
using GestionObra.Interfaces.AsistenciaContratista.DTOs;
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
    public class AsistenciaContratistaController : ControllerBase
    {
        private readonly IAsistenciaContratistaServicio _asistenciaContratistaRepositorio;
        private IMapper _mapper;
        public AsistenciaContratistaController(IAsistenciaContratistaServicio asistenciaContratistaRepositorio)
        {
            _asistenciaContratistaRepositorio = asistenciaContratistaRepositorio;
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
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.ObtenerTodos();
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
        }
        [HttpGet]
        [Route("GetDesde/{desde:datetime}/{hasta:datetime}/{id:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetDesde(DateTime desde,DateTime hasta,long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.ObtenerPorDesde(desde,hasta,id);
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
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
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.ObtenerPorFiltro(cadena);

            if (asistenciaContratistas == null)
            {
                return NotFound();
            }
            return Ok(asistenciaContratistas);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.ObtenerPorId(id);
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
        }

        [HttpGet("GetByJornal/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByJornal(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratistas = await _asistenciaContratistaRepositorio.ObtenerPorJornal(id);
            if (asistenciaContratistas == null)
            {
                return NotFound();
            }

            return Ok(asistenciaContratistas);
        }
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _asistenciaContratistaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, AsistenciaContratistaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var asistenciaContratista = _mapper.Map<AsistenciaContratistaDto>(model);
            asistenciaContratista.Id = id;
            await _asistenciaContratistaRepositorio.Modificar(asistenciaContratista);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(AsistenciaContratistaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var asistenciaContratista = _mapper.Map<AsistenciaContratistaDto>(model);
            await _asistenciaContratistaRepositorio.Insertar(asistenciaContratista);
            return Ok(model);
        }
    }
}