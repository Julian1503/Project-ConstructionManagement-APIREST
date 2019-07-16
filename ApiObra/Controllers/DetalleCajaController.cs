using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.DetalleCaja;
using GestionObra.Interfaces.DetalleCaja.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DetalleCajaController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IDetalleCajaRepositorio _detalleCajaRepositorio;

        public DetalleCajaController(IDetalleCajaRepositorio detalleCajaRepositorio)
        {
            _detalleCajaRepositorio = detalleCajaRepositorio;
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
            var detallesCaja = await _detalleCajaRepositorio.ObtenerTodos();
            if (detallesCaja == null)
            {
                return NotFound();
            }

            return Ok(detallesCaja);
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
            var detallesCaja = await _detalleCajaRepositorio.ObtenerConFiltro(cadena);

            if (detallesCaja == null)
            {
                return NotFound();
            }
            return Ok(detallesCaja);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var detallesCaja = await _detalleCajaRepositorio.ObtenerPorId(id);
            if (detallesCaja == null)
            {
                return NotFound();
            }

            return Ok(detallesCaja);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _detalleCajaRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, DetalleCajaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleCaja = _mapper.Map<DetalleCajaDto>(model);
            detalleCaja.Id = id;
            await _detalleCajaRepositorio.Modificar(detalleCaja);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(DetalleCajaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var detalleCaja = _mapper.Map<DetalleCajaDto>(model);
            await _detalleCajaRepositorio.Insertar(detalleCaja);
            return Ok(model);
        }
    }
}