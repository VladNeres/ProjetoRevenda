

using ApiRevenda.Exceptions;
using ApiRevenda.Services;
using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Data.Dto.DtoCategoria;
using CategoriaApi.Model;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CategoriaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private DatabaseContext _context;
        private IMapper _mapper;
        private CategoriaService _service;

        public CategoriaController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCategoria([FromBody] CreateCategoriaDto categoriaDto)
        {

            try
            {
                ReadCategoriaDto readDto = _service.AdicionarCategoria(categoriaDto);
                return CreatedAtAction(nameof(GetCategoriaPorId), new { id = readDto.Id }, readDto);

            }
            catch (AlreadyExistsException e)
            {

                return BadRequest(e.Message);
            }
            catch (MinCaracterException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditarCategoria(int id, [FromBody] UpdateCategoriaDto categoriaUpdateDto)
        {
           Result result = _service.EditarCategoria(id, categoriaUpdateDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCategoria(int id)
        {
            Categoria categoria = _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria == null)
            {
                return NoContent();
            }
            _context.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpGet]
        public IActionResult GetCategoria([FromQuery] string nomeCategoria, [FromQuery] bool? status, [FromQuery] int quantidadeDeCategorias,
            [FromQuery] string ordem , [FromQuery] bool? temSub)
        {
            List<Categoria> categorias = _context.Categorias.ToList();
            if (categorias == null)
            {
                return NotFound();
            }
            if (!string.IsNullOrEmpty(nomeCategoria))
            {
                IEnumerable<Categoria> query = from categoria in categorias
                                               orderby categoria.Nome ascending
                                               where categoria.Nome.ToUpper().StartsWith(nomeCategoria.ToUpper())
                                               select categoria;

                categorias = query.ToList();

            }
            if (status == true || status == false)
            {
                IEnumerable<Categoria> query = from categoria in categorias
                                               where categoria.Status == status
                                               select categoria;
                categorias = query.ToList();
            }
            if (quantidadeDeCategorias > 0 )
            {
                IEnumerable<Categoria> query = from categoria in categorias.Take(quantidadeDeCategorias)
                                               select categoria;
                categorias = query.ToList();
            }
            if (!string.IsNullOrEmpty(ordem) && ordem.ToUpper() == "CRESCENTE")
            {
                IEnumerable<Categoria> query = from categoria in categorias
                                               orderby categoria.Nome ascending
                                               select categoria;
                categorias = query.ToList();
            }
            if (!string.IsNullOrEmpty(ordem) && ordem.ToUpper() == "DECRESCENTE")
            {
                IEnumerable<Categoria> querydecres = from categoria in categorias
                                                     orderby categoria.Nome descending
                                                     select categoria;
                categorias = querydecres.ToList();
            }
            if (temSub == true && temSub != null)
            {
                IEnumerable<Categoria> query = from categoria in categorias
                                               where categoria.SubCategoria.Count() > 0
                                               select categoria;
                categorias = query.ToList();
            }
            if (temSub == false && temSub != null)
            {
                IEnumerable<Categoria> query = from categoria in categorias
                                               where categoria.SubCategoria.Count() == 0
                                               select categoria;
                categorias = query.ToList();
            }
            
            List<ReadCategoriaDto> readDto = _mapper.Map<List<ReadCategoriaDto>>(categorias);
            return Ok(readDto);

        }


        [HttpGet("{Id}")]
        public IActionResult GetCategoriaPorId(int id)
        {
                Categoria categoria= _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
            if (categoria != null)
            {
                ReadCategoriaDto reader = _mapper.Map<ReadCategoriaDto>(categoria);
                return Ok(categoria);

            }
            return NotFound("Não encontrado");
        }

    }
}
