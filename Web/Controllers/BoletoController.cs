using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly BoletoService _servicoBoleto;
        public BoletoController(BoletoService servicoBoleto)
        {
            _servicoBoleto = servicoBoleto;
        }

        [HttpGet("boletos")]
        public OkObjectResult ObterTodos()
        {
            var boletos = _servicoBoleto.ObterTodos();
            return Ok(boletos);
        }

        [HttpGet("boleto/{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var boleto = _servicoBoleto.ObterPorId(id);
            return Ok(boleto);
        }

        [HttpPost("boleto")]
        public CreatedResult Adicionar([FromBody] Boleto boleto)
        {
            _servicoBoleto.Adicionar(boleto);
            return Created();
        }

        [HttpPatch("boleto/{id}")]
        public OkResult Atualizar([FromBody] Boleto boleto)
        {
            _servicoBoleto.Editar(boleto);
            return Ok();
        }

        [HttpDelete("boleto/{id}")]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoBoleto.Remover(id);
            return Ok();
        }
    }
}
