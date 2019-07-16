using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.DetalleComprobante;
using GestionObra.Interfaces.DetalleComprobante.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class DetalleComprobanteController : ControllerBase
    {
        private readonly IDetalleComprobanteRepositorio _detalleComprobanteRepositorio;
        private IMapper _mapper;

        public DetalleComprobanteController(IDetalleComprobanteRepositorio detalleComprobanteRepositorio)
        {
            _detalleComprobanteRepositorio = detalleComprobanteRepositorio;
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
            var detallesComprobante = await _detalleComprobanteRepositorio.ObtenerTodos();
            if (detallesComprobante == null)
            {
                return NotFound();
            }

            return Ok(detallesComprobante);
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
            var detallesComprobante = await _detalleComprobanteRepositorio.ObtenerPorFiltro(cadena);

            if (detallesComprobante == null)
            {
                return NotFound();
            }
            return Ok(detallesComprobante);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var detallesComprobante = await _detalleComprobanteRepositorio.ObtenerPorId(id);
            if (detallesComprobante == null)
            {
                return NotFound();
            }

            return Ok(detallesComprobante);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _detalleComprobanteRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, DetalleComprobanteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var detalleComprobante = _mapper.Map<DetalleComprobanteDto>(model);
            detalleComprobante.Id = id;
            await _detalleComprobanteRepositorio.Modificar(detalleComprobante);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(DetalleComprobanteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var detalleComprobante = _mapper.Map<DetalleComprobanteDto>(model);
            await _detalleComprobanteRepositorio.Insertar(detalleComprobante);
            return Ok(model);
        }
    }
}