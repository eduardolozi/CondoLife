using Aplicacao.Dtos;
using Aplicacao.Servicos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcaoDeVotoController : ControllerBase
    {
        private readonly OpcaoDeVotoService _opcaoDeVotoService;
        public OpcaoDeVotoController(OpcaoDeVotoService opcaoDeVotoService)
        {
            _opcaoDeVotoService = opcaoDeVotoService;
        }

        [HttpGet("opcoes-de-voto")]
        public OkObjectResult ObterTodos()
        {
            var opcoesDeVoto = _opcaoDeVotoService.ObterTodos();
            return Ok(opcoesDeVoto);
        }

        [HttpGet("opcao-de-voto/{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var opcaoDeVoto = _opcaoDeVotoService.ObterPorId(id);
            return Ok(opcaoDeVoto);
        }

        [HttpPost("opcao-de-voto")]
        public CreatedResult Adicionar([FromBody] OpcaoDeVotoDto opcaoDeVoto)
        {
            _opcaoDeVotoService.Adicionar(opcaoDeVoto);
            return Created();
        }

        [HttpPatch("opcao-de-voto/{id}")]
        public OkResult Atualizar([FromRoute] int id, [FromBody] OpcaoDeVotoDto opcaoDeVoto)
        {
            _opcaoDeVotoService.Editar(id, opcaoDeVoto);
            return Ok();
        }

        [HttpDelete("opcao-de-voto/{id}")]
        public OkResult Remover([FromRoute] int id)
        {
            _opcaoDeVotoService.Remover(id);
            return Ok();
        }
    }
}
