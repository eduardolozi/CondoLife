using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _servicoUsuario;
        public UsuarioController(UsuarioService servicoUsuario) 
        { 
            _servicoUsuario = servicoUsuario;
        }

        [HttpGet("usuarios")]
        public OkObjectResult ObterTodos()
        {
            var usuarios = _servicoUsuario.ObterTodos();
            return Ok(usuarios);
        }

        [HttpGet("usuario/{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var usuario = _servicoUsuario.ObterPorId(id);
            return Ok(usuario);
        }

        [HttpPost("usuario")]
        public CreatedResult Adicionar([FromBody] Usuario usuario)
        {
            _servicoUsuario.Adicionar(usuario);
            return Created();
        }

        [HttpPatch("usuario/{id}")]
        public OkResult Atualizar([FromRoute] int id, [FromBody] Usuario usuario)
        {
            _servicoUsuario.Editar(id, usuario);
            return Ok();
        }

        [HttpDelete("usuario/{id}")]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoUsuario.Remover(id);
            return Ok();
        }
    }
}
