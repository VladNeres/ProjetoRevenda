using ApiRevenda.Services;
using AutoMapper;
using CategoriaApi.Data;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using RevendaApi.Data.Dto.DtoEndereco;

using System.Threading.Tasks;

namespace RevendaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController: ControllerBase
    {
        public DatabaseContext _context;
        public IMapper _mapper;
        private EnderecoService _enderecoService;

        public EnderecoController(DatabaseContext context, IMapper mapper, EnderecoService service)
        {
            _context = context;
            _mapper = mapper;
            _enderecoService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {
            ReadEnderecoDto endereco = await _enderecoService.AdicionarEndereco(enderecoDto);
            return CreatedAtAction(nameof(GetEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
           Result resultado= await _enderecoService.AtualizarEndereco(id,enderecoDto);
            if (resultado == null) return NotFound();
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetEndereco()
        {
            var enderecoPesquisa = _enderecoService.GetEndereco();
            return Ok(enderecoPesquisa);
        }

        [HttpGet("{id}")]
        public IActionResult GetEnderecoPorId (int id)
        {
           Result result = _enderecoService.GetEnderecoPorId(id);
            if(result==null) return NotFound();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarEnderecoPorId(int id)
        {
            Result resultado = _enderecoService.DeletarEnderecoPorId(id);
            if(resultado==null) return NotFound();
            return NoContent();
        }

        
    }
}
