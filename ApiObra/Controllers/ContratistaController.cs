using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Contratista;
using GestionObra.Interfaces.Contratista.DTOs;
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
    public class ContratistaController : ControllerBase
    {
        private readonly IContratistaServicio _contratistaRepositorio;
        private IMapper _mapper;

        public ContratistaController(IContratistaServicio contratistaRepositorio)
        {
            _contratistaRepositorio = contratistaRepositorio;
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
            var contratistas = await _contratistaRepositorio.ObtenerTodos();
            if (contratistas == null)
            {
                return NotFound();
            }

            return Ok(contratistas);
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
            var contratistas = await _contratistaRepositorio.ObtenerPorFiltro(cadena);

            if (contratistas == null)
            {
                return NotFound();
            }
            return Ok(contratistas);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contratistas = await _contratistaRepositorio.ObtenerPorId(id);
            if (contratistas == null)
            {
                return NotFound();
            }

            return Ok(contratistas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _contratistaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ContratistaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contratista = _mapper.Map<ContratistaDto>(model);
            contratista.Id = id;
            await _contratistaRepositorio.Modificar(contratista);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ContratistaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contratista = _mapper.Map<ContratistaDto>(model);
            await _contratistaRepositorio.Insertar(contratista);
            return Ok(model);
        }
    }
}