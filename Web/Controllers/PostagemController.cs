using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController(PostagemService servicoPostagem,
        IDistributedCache redis) : ControllerBase
    {
        private readonly PostagemService _servicoPostagem = servicoPostagem;
        private readonly IDistributedCache _redis = redis;

        [HttpGet("postagens")]
        public async Task<OkObjectResult> ObterTodos()
        {
            List<Postagem>? postagens;
            const string CacheKey = "postagens";

            var postagensNoRedis = await _redis.GetAsync(CacheKey);
            if(postagensNoRedis != null)
            {
                postagens = JsonSerializer.Deserialize<List<Postagem>>(postagensNoRedis);
                return Ok(postagens);
            }

            postagens = _servicoPostagem.ObterTodos();
            if(postagens != null)
            {
                var jsonPostagens = JsonSerializer.Serialize<List<Postagem>>(postagens);
                var bytesPostagens = Encoding.UTF8.GetBytes(jsonPostagens);
                var options = new DistributedCacheEntryOptions()
                          .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _redis.SetAsync(CacheKey, bytesPostagens, options);
            }

            return Ok(postagens);
        }

        [HttpGet("postagem/{id}")]
        public OkObjectResult ObterPorId([FromRoute] int id)
        {
            var usuario = _servicoPostagem.ObterPorId(id);
            return Ok(usuario);
        }

        [HttpPost("postagem")]
        public CreatedResult Adicionar([FromBody] Postagem postagem)
        {
            _servicoPostagem.Adicionar(postagem);
            return Created();
        }

        [HttpPatch("postagem/{id}")]
        public OkResult Atualizar([FromRoute] int id, [FromBody] Postagem postagem)
        {
            _servicoPostagem.Editar(id, postagem);
            return Ok();
        }

        [HttpDelete("postagem/{id}")]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoPostagem.Remover(id);
            return Ok();
        }
    }
}
