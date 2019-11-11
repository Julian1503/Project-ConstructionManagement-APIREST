using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ApiObra.Models;
using AutoMapper;
using GestionObra.Interfaces.Categoria;
using GestionObra.Interfaces.Categoria.DTOs;
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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriasRepositorio;
        private IMapper _mapper;
        public CategoriaController(ICategoriaServicio categoriasRepositorio)
        {
            _categoriasRepositorio = categoriasRepositorio;
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
            var categorias = await _categoriasRepositorio.ObtenerTodos();
            if (categorias == null)
            {
                return NotFound();
            }

            return Ok(categorias);
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
            var categorias = await _categoriasRepositorio.ObtenerPorFiltro(cadena);

            if (categorias == null)
            {
                return NotFound();
            }
            return Ok(categorias);

        }

        [HttpGet("GetById/{id:int}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categorias = await _categoriasRepositorio.ObtenerPorId(id);
            if (categorias == null)
            {
                return NotFound();
            }

            return Ok(categorias);
        }

        [HttpDelete("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _categoriasRepositorio.Borrar(id);
            return Ok(id);
        }

        [HttpPut("{id}")]
        [EnableCors("_myPolicy")]
        public async Task<IActionResult> Edit(long id, CategoriaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = _mapper.Map<CategoriaDto>(model);
            categoria.Id = id;
            await _categoriasRepositorio.Modificar(categoria);
            return Ok(model);
        }

        [HttpPost]
        [EnableCors("_myPolicy")]
        [Route("Insert")]
        public async Task<IActionResult> Insert(CategoriaModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoria = _mapper.Map<CategoriaDto>(model);
            await _categoriasRepositorio.Insertar(categoria);
            return Ok(model);
        }
    }
}