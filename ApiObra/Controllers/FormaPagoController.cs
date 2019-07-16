using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.FormaPago;
using GestionObra.Interfaces.FormaPago.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiObra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class FormaPagoController : ControllerBase
    {
        private readonly IFormaPagoRepositorio _formaPagoRepositorio;
        private IMapper _mapper;

        public FormaPagoController(IFormaPagoRepositorio formaPagoRepositorio)
        {
            _formaPagoRepositorio = formaPagoRepositorio;
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
            var formasPago = await _formaPagoRepositorio.ObtenerTodos();
            if (formasPago == null)
            {
                return NotFound();
            }

            return Ok(formasPago);
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
            var formasPago = await _formaPagoRepositorio.ObtenerConFiltro(cadena);

            if (formasPago == null)
            {
                return NotFound();
            }
            return Ok(formasPago);

        }

        [HttpGet("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var formasPago = await _formaPagoRepositorio.ObtenerPorId(id);
            if (formasPago == null)
            {
                return NotFound();
            }

            return Ok(formasPago);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _formaPagoRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, FormaPagoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var formaPago = _mapper.Map<FormaPagoDto>(model);
            formaPago.Id = id;
            await _formaPagoRepositorio.Modificar(formaPago);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(FormaPagoModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var formaPago = _mapper.Map<FormaPagoDto>(model);
            await _formaPagoRepositorio.Insertar(formaPago);
            return Ok(model);
        }
    }
}