using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Empleado;
using GestionObra.Interfaces.Empleado.DTOs;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServicio _empleadoRepositorio;
        private IMapper _mapper;
        public EmpleadoController(IEmpleadoServicio empleadoRepositorio)
        {
            _empleadoRepositorio = empleadoRepositorio;
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
            var empleados = await _empleadoRepositorio.ObtenerTodos();
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
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
            var empleados = await _empleadoRepositorio.ObtenerConFiltro(cadena);

            if (empleados == null)
            {
                return NotFound();
            }
            return Ok(empleados);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var empleados = await _empleadoRepositorio.ObtenerPorId(id);
            if (empleados == null)
            {
                return NotFound();
            }

            return Ok(empleados);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _empleadoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, EmpleadoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empleado = _mapper.Map<EmpleadoDto>(model);
            empleado.Id = id;
            await _empleadoRepositorio.Modificar(empleado);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(EmpleadoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var empleado = _mapper.Map<EmpleadoDto>(model);
            await _empleadoRepositorio.Insertar(empleado);
            return Ok(model);
        }
    }
}