using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.ChequeSalida;
using GestionObra.Interfaces.ChequeSalida.DTOs;
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
    public class ChequeSalidaController : ControllerBase
    {
        private readonly IChequeSalidaServicio _chequeSalidaServicio;
        private IMapper _mapper;
        public ChequeSalidaController(IChequeSalidaServicio chequeSalidaServicio)
        {
            _chequeSalidaServicio = chequeSalidaServicio;
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
            var chequeSalidas = await _chequeSalidaServicio.ObtenerTodos();
            if (chequeSalidas == null)
            {
                return NotFound();
            }

            return Ok(chequeSalidas);
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
            var presupuestos = await _chequeSalidaServicio.ObtenerPorDesde(desde, hasta);
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
            var presupuestos = await _chequeSalidaServicio.ObtenerPorConcepto(desde, hasta,concepto);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByDePara/{desde:datetime}/{hasta:datetime}/{dePara}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByDePara(DateTime desde, DateTime hasta, string dePara)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _chequeSalidaServicio.ObtenerPorDePara(desde, hasta, dePara);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByTodo/{desde:datetime}/{hasta:datetime}/{paguese}/{concepto}/{numero}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByTodo(DateTime desde, DateTime hasta,string paguese,string concepto,string numero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _chequeSalidaServicio.ObtenerPorTodo(desde, hasta,paguese,concepto,numero);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
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
            var chequeSalidas = await _chequeSalidaServicio.ObtenerPorFiltro(cadena);

            if (chequeSalidas == null)
            {
                return NotFound();
            }
            return Ok(chequeSalidas);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chequeSalidas = await _chequeSalidaServicio.ObtenerPorId(id);
            if (chequeSalidas == null)
            {
                return NotFound();
            }

            return Ok(chequeSalidas);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _chequeSalidaServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ChequeSalidaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var chequeSalida = _mapper.Map<ChequeSalidaDto>(model);
            chequeSalida.Id = id;
            await _chequeSalidaServicio.Modificar(chequeSalida);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ChequeSalidaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var chequeSalida = _mapper.Map<ChequeSalidaDto>(model);
            await _chequeSalidaServicio.Insertar(chequeSalida);
            return Ok(model);
        }
    }
}