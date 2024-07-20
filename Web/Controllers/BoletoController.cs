using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Dtos;

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
        
        [HttpGet("boletos-usuario/{idUsuario}")]
        public OkObjectResult ObterBoletosDoUsuario([FromRoute] int idUsuario)
        {
            var boletos = _servicoBoleto.ObterBoletosDoUsuario(idUsuario);
            return Ok(boletos);
        }

        [HttpPost("boleto")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public CreatedResult Adicionar([FromBody] BoletoDto boleto)
        {
            _servicoBoleto.Adicionar(boleto);
            return Created();
        }

        [HttpPatch("boleto/{id}")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public OkResult Atualizar([FromRoute] int id, [FromBody] BoletoDto boleto)
        {
            _servicoBoleto.Editar(id, boleto);
            return Ok();
        }

        [HttpDelete("boleto/{id}")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoBoleto.Remover(id);
            return Ok();
        }
    }
}
