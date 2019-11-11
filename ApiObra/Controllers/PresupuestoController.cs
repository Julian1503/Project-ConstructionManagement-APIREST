using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Constantes;
using GestionObra.Infraestructura;
using GestionObra.Interfaces.Presupuesto;
using GestionObra.Interfaces.Presupuesto.DTOs;
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
        [HttpGet]
        [Route("GetAprobado")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Aprobado()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _presupuestoRepositorio.ObtenerFinalizados();
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetFacturado")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Facturado()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _presupuestoRepositorio.ObtenerFacturados();
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
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
            var presupuestos = await _presupuestoRepositorio.ObtenerPorFecha(desde,hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet]
        [Route("GetByFacturadoFecha/{desde:datetime}/{hasta:datetime}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByFac(DateTime desde, DateTime hasta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _presupuestoRepositorio.ObtenerFacturadosFecha(desde, hasta);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }
        [HttpGet]
        [Route("GetByCliente/{desde:datetime}/{hasta:datetime}/{clienteId:long}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetByCliente(DateTime desde, DateTime hasta,long clienteId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var presupuestos = await _presupuestoRepositorio.ObtenerPorCliente(desde, hasta,clienteId);
            if (presupuestos == null)
            {
                return NotFound();
            }

            return Ok(presupuestos);
        }

        [HttpGet("UltimoNumero")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> UltimoNumero()
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
            if (presupuestos.Count() == 0)
            {
                return Ok(1);
            }
            return Ok(presupuestos.Max(x => x.Numero) + 1);
        }

        [HttpGet("SinCobrar")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> NumeroPresupuestos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var cantidad = await _presupuestoRepositorio.ObtenerSinCobrar();
            if (cantidad == null)
            {
                return NotFound();
            }
            return Ok(cantidad);
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
        [Route("GetByFilter/{cadena}")]
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

         [HttpGet("GetById/{id:int}")]
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