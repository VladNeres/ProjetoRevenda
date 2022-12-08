using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using Microsoft.AspNetCore.Mvc;
using RevendaApi.Data.Dto.ClienteDto;
using System;
using System.Linq;

namespace CategoriaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController: ControllerBase
    {
        private DatabaseContext _context;
        private IMapper _mapper;
        public ClienteController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCliente([FromBody] CreateClienteDto clienteDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetClientePorId), new { Id = cliente.Id }, cliente);

            }
            catch (Exception)
            {

                return BadRequest("Para criar o cliente, é necessario informar o Id do endereço onde ele(a) mora");
            }
        }

        [HttpPut("{Id}")]
        public IActionResult AtualizarCliente(int id, UpDateClienteDto clienteDto)
        {
            var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if(cliente== null)
            {
                return NotFound();
            }
            _mapper.Map(clienteDto, cliente);
                _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult ExcluirCliente(int id)
        {
            var excluirClienteporId = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (excluirClienteporId == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(excluirClienteporId);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetCliente()
        {
            return Ok(_context.Clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientePorId(int id)
        {
            Cliente clienteporId= _context.Clientes.FirstOrDefault(cliente=> cliente.Id == id);
            if( clienteporId != null)
            {
                ReadClienteDto cliente = _mapper.Map<ReadClienteDto>(clienteporId);
                return Ok(clienteporId);
            }
                return NotFound();
        }

    }
}
