using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.CuentaCorriente;
using GestionObra.Interfaces.CuentaCorriente.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CuentaCorrienteController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ICuentaCorrienteRepositorio _cuentaCorrienteRepositorio;


        public CuentaCorrienteController(ICuentaCorrienteRepositorio cuentaCorrienteRepositorio)
        {
            _cuentaCorrienteRepositorio = cuentaCorrienteRepositorio;
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
            var cuentasCorriente = await _cuentaCorrienteRepositorio.ObtenerTodos();
            if (cuentasCorriente == null)
            {
                return NotFound();
            }

            return Ok(cuentasCorriente);
        }

        [HttpGet]
        [Route("GetByFilter")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFilter(string cadena)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cuentasCorriente = await _cuentaCorrienteRepositorio.ObtenerConFiltro(cadena);

            if (cuentasCorriente == null)
            {
                return NotFound();
            }
            return Ok(cuentasCorriente);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cuentasCorriente = await _cuentaCorrienteRepositorio.ObtenerPorId(id);
            if (cuentasCorriente == null)
            {
                return NotFound();
            }

            return Ok(cuentasCorriente);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _cuentaCorrienteRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, CuentaCorrienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cuentaCorriente = _mapper.Map<CuentaCorrienteDto>(model);
            cuentaCorriente.Id = id;
            await _cuentaCorrienteRepositorio.Modificar(cuentaCorriente);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(CuentaCorrienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cuentaCorriente = _mapper.Map<CuentaCorrienteDto>(model);
            await _cuentaCorrienteRepositorio.Insertar(cuentaCorriente);
            return Ok(model);
        }
    }

}