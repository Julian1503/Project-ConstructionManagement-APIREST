using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.TipoGasto;
using GestionObra.Interfaces.TipoGasto.DTOs;
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
    public class TipoGastoController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ITipoGastoRepositorio _tipoGastoRepositorio;

        public TipoGastoController(ITipoGastoRepositorio tipoGastoRepositorio)
        {
            _tipoGastoRepositorio = tipoGastoRepositorio;
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
            var tipoGastos = await _tipoGastoRepositorio.ObtenerTodos();
            if (tipoGastos == null)
            {
                return NotFound();
            }

            return Ok(tipoGastos);
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
            var tipoGastos = await _tipoGastoRepositorio.ObtenerPorFiltro(cadena);

            if (tipoGastos == null)
            {
                return NotFound();
            }
            return Ok(tipoGastos);

        }

         [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tipoGastos = await _tipoGastoRepositorio.ObtenerPorId(id);
            if (tipoGastos == null)
            {
                return NotFound();
            }

            return Ok(tipoGastos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _tipoGastoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, TipoGastoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoGasto = _mapper.Map<TipoGastoDto>(model);
            tipoGasto.Id = id;
            await _tipoGastoRepositorio.Modificar(tipoGasto);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(TipoGastoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tipoGasto = _mapper.Map<TipoGastoDto>(model);
            await _tipoGastoRepositorio.Insertar(tipoGasto);
            return Ok(model);
        }
    }
}