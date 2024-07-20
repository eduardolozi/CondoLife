using Aplicacao.Dtos;
using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using Web.Dtos;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController(ComentarioService servicoComentario,
        IDistributedCache redis) : ControllerBase
    {
        private readonly ComentarioService _servicoComentario = servicoComentario;
        private readonly IDistributedCache _redis = redis;

        [HttpGet("comentarios")]
        public OkObjectResult ObterTodos()
        {
            var comentarios = _servicoComentario.ObterTodos();
            return Ok(comentarios);
        }

        [HttpGet("comentarios/{idPostagem}")]
        public async Task<OkObjectResult> ObterComentariosDaPostagem([FromRoute] int idPostagem)
        {
            List<Comentario>? comentarios;
            string CacheKey = $"comentarios{idPostagem}";

            var comentariosNoRedis = await _redis.GetAsync(CacheKey);
            if (comentariosNoRedis != null)
            {
                comentarios = JsonSerializer.Deserialize<List<Comentario>>(comentariosNoRedis);
                return Ok(comentarios);
            }

            comentarios = _servicoComentario.ObterComentariosDaPostagem(idPostagem);
            if (comentarios != null)
            {
                var jsonComentarios = JsonSerializer.Serialize<List<Comentario>>(comentarios);
                var bytesComentarios = Encoding.UTF8.GetBytes(jsonComentarios);
                var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _redis.SetAsync(CacheKey, bytesComentarios, options);
            }

            return Ok(comentarios);
        }


        [HttpGet("comentario/{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var comentario = _servicoComentario.ObterPorId(id);
            return Ok(comentario);
        }

        [HttpPost("comentario")]
        [Authorize]
        public CreatedResult Adicionar([FromBody] ComentarioDto comentario)
        {
            _servicoComentario.Adicionar(comentario);
            return Created();
        }

        [HttpPatch("comentario/{id}")]
        [Authorize]
        public OkResult Atualizar([FromRoute] int id, [FromBody] ComentarioDto comentario)
        {
            _servicoComentario.Editar(id, comentario);
            return Ok();
        }

        [HttpDelete("comentario/{id}")]
        [Authorize]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoComentario.Remover(id);
            return Ok();
        }
    }
}
