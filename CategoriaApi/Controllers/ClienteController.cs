using ApiRevenda.Interfaces;
using ApiRevenda.Services;
using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using RevendaApi.Data.Dto.ClienteDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CategoriaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController: ControllerBase
    {
       
        private IServiceCliente _clienteservice;

        public ClienteController(IServiceCliente service)
        {
            _clienteservice = service;
           
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                ReadClienteDto readClienteDto = _clienteservice.AdicionarCliente(clienteDto);
                return CreatedAtAction(nameof(GetClientePorId), new { Id = readClienteDto.Id }, readClienteDto);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Para criar o cliente, é necessario informar o Id do endereço onde ele(a) mora");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarCliente(int id, UpDateClienteDto clienteDto)
        {
            Result resultado = _clienteservice.AtualizarCliente(id, clienteDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirCliente(int id)
        {
            Result resultado = _clienteservice.ExcluiCliente(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetCliente()
        {
            return Ok(_clienteservice.PesquisarListaCliente());
            
        }

        [HttpGet("{id}")]
        public IActionResult GetClientePorId(int id)
        {
            ReadClienteDto clienteDto = _clienteservice.GetClientePorId(id);
            if(clienteDto == null) return NotFound();
                return NotFound();
        }
    }
}
