using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Operacion;
using GestionObra.Interfaces.Operacion.DTOs;
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
    public class OperacionController : ControllerBase
    {
        private readonly IOperacionServicio _operacionServicio;
        private IMapper _mapper;

        public OperacionController(IOperacionServicio operacionServicio)
        {
            _operacionServicio = operacionServicio;
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
            var operacions = await _operacionServicio.ObtenerTodos();
            if (operacions == null)
            {
                return NotFound();
            }

            return Ok(operacions);
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
            var operacions = await _operacionServicio.ObtenerPorFiltro(cadena);

            if (operacions == null)
            {
                return NotFound();
            }
            return Ok(operacions);

        }

        [HttpGet]
        [Route("GetByFecha/{desde:datetime}/{hasta:datetime}/{cuentaCorrienteId:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFilter(DateTime desde,DateTime hasta, long cuentaCorrienteId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operacions = await _operacionServicio.ObtenerPorTiempo(desde,hasta,cuentaCorrienteId);

            if (operacions == null)
            {
                return NotFound();
            }
            return Ok(operacions);

        }
        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operacions = await _operacionServicio.ObtenerPorId(id);
            if (operacions == null)
            {
                return NotFound();
            }

            return Ok(operacions);
        }
        [HttpGet("GetByBanco/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByBanco(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operacions = await _operacionServicio.ObtenerPorBanco(id);
            if (operacions == null)
            {
                return NotFound();
            }

            return Ok(operacions);
        }
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _operacionServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, OperacionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operacion = _mapper.Map<OperacionDto>(model);
            operacion.Id = id;
            await _operacionServicio.Modificar(operacion);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(OperacionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var operacion = _mapper.Map<OperacionDto>(model);
            await _operacionServicio.Insertar(operacion);
            return Ok(model);
        }
    }
}