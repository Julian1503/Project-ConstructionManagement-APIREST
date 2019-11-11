using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.ComprobanteCompra;
using GestionObra.Interfaces.ComprobanteCompra.DTOs;
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
    public class ComprobanteCompraController : ControllerBase
    {
        private readonly IComprobanteCompraServicio _comprobanteCompraServicio;
        private IMapper _mapper;
        public ComprobanteCompraController(IComprobanteCompraServicio comprobanteCompraServicio)
        {
            _comprobanteCompraServicio = comprobanteCompraServicio;
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
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerTodos();
            if (comprobanteCompras == null)
            {
                return NotFound();
            }

            return Ok(comprobanteCompras);
        }
        [HttpGet]
        [Route("GetOficina")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetOficina()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerOficina();
            if (comprobanteCompras == null)
            {
                return Ok(0);
            }

            return Ok(comprobanteCompras);
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
            var presupuestos = await _comprobanteCompraServicio.ObtenerPorDesde(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByFechaObra/{desde:datetime}/{hasta:datetime}/{id:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFecha(DateTime desde, DateTime hasta,long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteCompraServicio.ObtenerPorObraFecha(desde, hasta,id);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByCuit/{desde:datetime}/{hasta:datetime}/{cuit}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByCuit(DateTime desde, DateTime hasta,string cuit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteCompraServicio.ObtenerPorCuit(desde, hasta,cuit);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetByProveedor/{desde:datetime}/{hasta:datetime}/{id:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByProveedor(DateTime desde, DateTime hasta,long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _comprobanteCompraServicio.ObtenerPorProveedor(desde, hasta,id);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetLast")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetLast()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerSiguienteId();
            if (comprobanteCompras == null)
            {
                return NotFound();
            }

            return Ok(comprobanteCompras);
        }
        [HttpGet]
        [Route("GetUltimo")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetUltimo()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerUltimo();
            if (comprobanteCompras == null)
            {
                return NotFound();
            }

            return Ok(comprobanteCompras);
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
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerPorFiltro(cadena);

            if (comprobanteCompras == null)
            {
                return NotFound();
            }
            return Ok(comprobanteCompras);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerPorId(id);
            if (comprobanteCompras == null)
            {
                return NotFound();
            }

            return Ok(comprobanteCompras);
        }
        [HttpGet("GetByObra/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByObra(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompras = await _comprobanteCompraServicio.ObtenerPorObra(id);
            if (comprobanteCompras == null)
            {
                return NotFound();
            }

            return Ok(comprobanteCompras);
        }
        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _comprobanteCompraServicio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ComprobanteCompraModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comprobanteCompra = _mapper.Map<ComprobanteCompraDto>(model);
            comprobanteCompra.Id = id;
            await _comprobanteCompraServicio.Modificar(comprobanteCompra);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ComprobanteCompraModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comprobanteCompra = _mapper.Map<ComprobanteCompraDto>(model);
            await _comprobanteCompraServicio.Insertar(comprobanteCompra);
            return Ok(model);
        }
    }
}