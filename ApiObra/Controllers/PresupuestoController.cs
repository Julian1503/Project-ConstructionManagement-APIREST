using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Constantes;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Presupuesto;
using GestionObra.Interfaces.Presupuesto.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PresupuestoController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IPresupuestoRepositorio _presupuestoRepositorio;
        public PresupuestoController(IPresupuestoRepositorio presupuestoRepositorio)
        {
            _presupuestoRepositorio = presupuestoRepositorio;
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
            var presupuestos = await _presupuestoRepositorio.ObtenerTodos();
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpPut]
        [Route("ChangeState")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> CambioEstado(EstadoPresupuesto estado, long id)
        {
            using (var context = new DataContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var presupuesto = await _presupuestoRepositorio.ObtenerPorId(id);
                if (presupuesto == null)
                {
                    return NotFound();
                }
                presupuesto.EstadoPresupuesto = estado;
                await _presupuestoRepositorio.Modificar(presupuesto);
                return Ok(estado);
            }
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
            var presupuestos = await _presupuestoRepositorio.ObtenerPorFiltro(cadena);

            if (presupuestos == null)
            {
                return NotFound();
            }
            return Ok(presupuestos);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _presupuestoRepositorio.ObtenerPorId(id);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _presupuestoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, PresupuestoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var presupuesto = _mapper.Map<PresupuestoDto>(model);
            presupuesto.Id = id;
            await _presupuestoRepositorio.Modificar(presupuesto);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(PresupuestoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuesto = _mapper.Map<PresupuestoDto>(model);
            await _presupuestoRepositorio.Insertar(presupuesto);
            return Ok(model);
        }
    }
}