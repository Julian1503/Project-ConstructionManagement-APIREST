using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Proveedor;
using GestionObra.Interfaces.Proveedor.DTOs;
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
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorServicio _proveedorRepositorio;
        private IMapper _mapper;
        public ProveedorController(IProveedorServicio proveedorRepositorio)
        {
            _proveedorRepositorio = proveedorRepositorio;
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
            var bancos = await _proveedorRepositorio.ObtenerTodos();
            if (bancos == null)
            {
                return NotFound();
            }

            return Ok(bancos);
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
            var bancos = await _proveedorRepositorio.Obtener(cadena);

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
            var bancos = await _proveedorRepositorio.ObtenerPorId(id);
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
            await _proveedorRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, ProveedorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proveedor = _mapper.Map<ProveedorDto>(model);
            proveedor.Id = id;
            await _proveedorRepositorio.Modificar(proveedor);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ProveedorModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var proveedor = _mapper.Map<ProveedorDto>(model);
            await _proveedorRepositorio.Insertar(proveedor);
            return Ok(model);
        }
    }
}