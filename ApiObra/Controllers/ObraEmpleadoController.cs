using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Jornal;
using GestionObra.Interfaces.Jornal.DTOs;
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
    public class ObraEmpleadoController : ControllerBase
    {
        private readonly IObraEmpleadoServicio _obraEmpleadoRepositorio;
        private IMapper _mapper;
        public ObraEmpleadoController(IObraEmpleadoServicio obraEmpleadoRepositorio)
        {
            _obraEmpleadoRepositorio = obraEmpleadoRepositorio;
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
            var jornalEmpleados = await _obraEmpleadoRepositorio.ObtenerTodos();
            if (jornalEmpleados == null)
            {
                return NotFound();
            }

            return Ok(jornalEmpleados);
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
            var jornalEmpleados = await _obraEmpleadoRepositorio.ObtenerPorFiltro(cadena);

            if (jornalEmpleados == null)
            {
                return NotFound();
            }
            return Ok(jornalEmpleados);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalEmpleados = await _obraEmpleadoRepositorio.ObtenerPorId(id);
            if (jornalEmpleados == null)
            {
                return NotFound();
            }

            return Ok(jornalEmpleados);
        }

        [HttpGet("GetByObra/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByJonal(long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalEmpleados = await _obraEmpleadoRepositorio.ObtenerPorObra(id);
            if (jornalEmpleados == null)
            {
                return NotFound();
            }

            return Ok(jornalEmpleados);
        }
        [HttpGet("GetByObraEmpleado/{obraId:int}/{empleadoId:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByJonal(long obraId,long empleadoId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalEmpleados = await _obraEmpleadoRepositorio.ObtenerPorObraEmpleado(obraId,empleadoId);
            if (jornalEmpleados == null)
            {
                return NotFound();
            }

            return Ok(jornalEmpleados);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _obraEmpleadoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, JornalEmpleadoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var jornalEmpleado = _mapper.Map<ObraEmpleadoDto>(model);
            jornalEmpleado.Id = id;
            await _obraEmpleadoRepositorio.Modificar(jornalEmpleado);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(JornalEmpleadoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var jornalEmpleado = _mapper.Map<ObraEmpleadoDto>(model);
            await _obraEmpleadoRepositorio.Insertar(jornalEmpleado);
            return Ok(model);
        }
    }
}