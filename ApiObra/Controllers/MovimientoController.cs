using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Movimiento;
using GestionObra.Interfaces.Movimiento.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoRepositorio _movimientoRepositorio;
        private IMapper _mapper;

        public MovimientoController(IMovimientoRepositorio movimientoRepositorio)
        {
            _movimientoRepositorio = movimientoRepositorio;
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
            var movimientos = await _movimientoRepositorio.ObtenerTodos();
            if (movimientos == null)
            {
                return NotFound();
            }

            return Ok(movimientos);
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
            var movimientos = await _movimientoRepositorio.ObtenerPorFiltro(cadena);

            if (movimientos == null)
            {
                return NotFound();
            }
            return Ok(movimientos);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var movimientos = await _movimientoRepositorio.ObtenerPorId(id);
            if (movimientos == null)
            {
                return NotFound();
            }

            return Ok(movimientos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _movimientoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, MovimientoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movimiento = _mapper.Map<MovimientoDto>(model);
            movimiento.Id = id;
            await _movimientoRepositorio.Modificar(movimiento);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(MovimientoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var movimiento = _mapper.Map<MovimientoDto>(model);
            await _movimientoRepositorio.Insertar(movimiento);
            return Ok(model);
        }
    }
}