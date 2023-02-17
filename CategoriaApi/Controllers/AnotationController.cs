using ApiRevenda.Data.Dto.Anotacoes;
using ApiRevenda.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiRevenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnotationController:ControllerBase
    {
        private readonly AnotacaoService _service;
        public AnotationController(AnotacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult CriandoAnotacao(CreateAnotacaoDto anotacao)
        {
            Result result = _service.CriarAnotacao(anotacao);
            if (result.IsFailed) return BadRequest("Falha ao cirar anotação");
            return Ok(result);
        }
    }
}
