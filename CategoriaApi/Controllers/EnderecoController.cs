using AutoMapper;
using CategoriaApi.Data;
using CategoriaApi.Model;
using Microsoft.AspNetCore.Mvc;
using RevendaApi.Data.Dto.DtoEndereco;
using System.Linq;

namespace RevendaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController: ControllerBase
    {
        public DatabaseContext _context;
        public IMapper _mapper;

        public EnderecoController(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco != null)
            {
                _mapper.Map(enderecoDto, endereco);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            return Ok(_context.Enderecos);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnderecoPorId (int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if(endereco != null)
            {
                ReadEnderecoDto enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
                return Ok(endereco);
            }
            return NotFound();
        }
    }
}
