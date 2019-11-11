using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.ComprobanteSalida;
using GestionObra.Interfaces.ComprobanteSalida.DTOs;
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
    public class ComprobanteSalidaController : ControllerBase
    {
        private readonly IComprobanteSalidaRepositorio _comprobanteRepositorio;
        private IMapper _mapper;
        public ComprobanteSalidaController(IComprobanteSalidaRepositorio comprobanteRepositorio)
        {
            _comprobanteRepositorio = comprobanteRepositorio;
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
            var bancos = await _comprobanteRepositorio.ObtenerTodos();
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
        }

        [HttpGet("GetPorcentaje")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetPorcentaje()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobantes = await _comprobanteRepositorio.ObtenerPorcentajes();
            if (comprobantes == null)
            {
                return NotFound();
            }

            return Ok(comprobantes);
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
            var bancos = await _comprobanteRepositorio.Obtener(cadena);

            if (bancos == null)
            {
                return NotFound();
            }
            return Ok(bancos);

        }
        [HttpGet]
        [Route("GetByFecha/{desde:datetime}/{hasta:datetime}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFecha(DateTime desde, DateTime hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteRepositorio.ObtenerPorDesde(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetByRubro/{desde:datetime}/{hasta:datetime}/{rubroId:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByRubro(DateTime desde, DateTime hasta, long rubroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteRepositorio.ObtenerPorRubro(desde, hasta, rubroId);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetBySubRubro/{desde:datetime}/{hasta:datetime}/{subRubroId:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetBySubRubro(DateTime desde, DateTime hasta, long subRubroId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteRepositorio.ObtenerPorSubRubro(desde, hasta, subRubroId);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet("GetLast")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetLast()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobantes = await _comprobanteRepositorio.ObtenerSiguienteId();
            if (comprobantes == null)
            {
                return NotFound();
            }

            return Ok(comprobantes);
        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bancos = await _comprobanteRepositorio.ObtenerPorId(id);
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _comprobanteRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ComprobanteSalidaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banco = _mapper.Map<ComprobanteSalidaDto>(model);
            banco.Id = id;
            await _comprobanteRepositorio.Modificar(banco);
            return Ok(model);
        }



        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ComprobanteSalidaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var banco = _mapper.Map<ComprobanteSalidaDto>(model);
            var a = await _comprobanteRepositorio.Insertar(banco);
            return Ok(a);
        }
    }
}