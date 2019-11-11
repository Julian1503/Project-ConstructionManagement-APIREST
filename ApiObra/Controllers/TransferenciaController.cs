using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Transferencia;
using GestionObra.Interfaces.Transferencia.DTOs;
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
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaServicio _transferenciaServicio;
        private IMapper _mapper;
        public TransferenciaController(ITransferenciaServicio transferenciaServicio)
        {
            _transferenciaServicio = transferenciaServicio;
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
            var bancos = await _transferenciaServicio.ObtenerTodos();
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
            var presupuestos = await _transferenciaServicio.ObtenerPorDesde(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByConcepto/{desde:datetime}/{hasta:datetime}/{concepto}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByConcepto(DateTime desde, DateTime hasta,string concepto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _transferenciaServicio.ObtenerPorConcepto(desde, hasta,concepto);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetByPaguese/{desde:datetime}/{hasta:datetime}/{paguese}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFecha(DateTime desde, DateTime hasta,string paguese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _transferenciaServicio.ObtenerPorPaguese(desde, hasta,paguese);
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
            var transferencias = await _transferenciaServicio.ObtenerSiguienteId();
            if (transferencias == null)
            {
                return NotFound();
            }

            return Ok(transferencias);
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
            var bancos = await _transferenciaServicio.Obtener(cadena);

            if (bancos == null)
            {
                return NotFound();
            }
            return Ok(bancos);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bancos = await _transferenciaServicio.ObtenerPorId(id);
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
            await _transferenciaServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, TransferenciaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var banco = _mapper.Map<TransferenciaDto>(model);
            banco.Id = id;
            await _transferenciaServicio.Modificar(banco);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(TransferenciaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var banco = _mapper.Map<TransferenciaDto>(model);
            var a = await _transferenciaServicio.Insertar(banco);
            return Ok(a);
        }
    }
}