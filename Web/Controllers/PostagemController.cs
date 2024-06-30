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
        public async Task<OkObjectResult>ObterPorId([FromRoute] int id)
        {
            Postagem? postagem;
            var cacheKey = $"postagem{id}";

            var postagemNoRedis = await _redis.GetAsync(cacheKey);
            if(postagemNoRedis != null)
            {
                postagem = JsonSerializer.Deserialize<Postagem>(postagemNoRedis);
                return Ok(postagem);
            }

            postagem = _servicoPostagem.ObterPorId(id);
            var jsonPostagem = JsonSerializer.Serialize(postagem);
            var bytesPostagem = Encoding.UTF8.GetBytes(jsonPostagem);
            var options = new DistributedCacheEntryOptions()
                          .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            await _redis.SetAsync(cacheKey, bytesPostagem, options);

            return Ok(postagem);
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
