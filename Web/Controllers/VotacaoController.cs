using Aplicacao.Servicos;
using Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Text;
using Web.Dtos;
using Aplicacao.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotacaoController(VotacaoService servicoVotacao,
        IDistributedCache redis) : ControllerBase
    {
        private readonly VotacaoService _servicoVotacao = servicoVotacao;
        private readonly IDistributedCache _redis = redis;

        [HttpGet("votacao")]
        public async Task<OkObjectResult> ObterTodos()
        {
            List<Votacao>? votacao;
            const string CacheKey = "votacao";

            var votacoesNoRedis = await _redis.GetAsync(CacheKey);
            if (votacoesNoRedis != null)
            {
                votacao = JsonSerializer.Deserialize<List<Votacao>>(votacoesNoRedis);
                return Ok(votacao);
            }

            votacao = _servicoVotacao.ObterTodos();
            if (votacao != null)
            {
                var jsonVotacoes = JsonSerializer.Serialize<List<Votacao>>(votacao);
                var bytesVotacoes = Encoding.UTF8.GetBytes(jsonVotacoes);
                var options = new DistributedCacheEntryOptions()
                          .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await _redis.SetAsync(CacheKey, bytesVotacoes, options);
            }

            return Ok(votacao);
        }

        [HttpGet("votacao/{id}")]
        public async Task<OkObjectResult> ObterPorId([FromRoute] int id)
        {
            Votacao? votacao;
            var cacheKey = $"votacao{id}";

            var votacaoNoRedis = await _redis.GetAsync(cacheKey);
            if (votacaoNoRedis != null)
            {
                votacao = JsonSerializer.Deserialize<Votacao>(votacaoNoRedis);
                return Ok(votacao);
            }

            votacao = _servicoVotacao.ObterPorId(id);
            var jsonVotacao = JsonSerializer.Serialize(votacao);
            var bytesVotacao = Encoding.UTF8.GetBytes(jsonVotacao);
            var options = new DistributedCacheEntryOptions()
                          .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                          .SetSlidingExpiration(TimeSpan.FromMinutes(2));
            await _redis.SetAsync(cacheKey, bytesVotacao, options);

            return Ok(votacao);
        }

        [HttpPost("votacao")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public async Task<CreatedResult> Adicionar([FromBody] VotacaoDto votacao)
        {
            await _servicoVotacao.Adicionar(votacao);
            return Created();
        }

        [HttpPatch("votacao/{id}")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public OkResult Atualizar([FromRoute] int id, [FromBody] VotacaoDto votacao)
        {
            _servicoVotacao.Editar(id, votacao);
            return Ok();
        }

        [HttpDelete("votacao/{id}")]
        [Authorize(Policy = "SINDICO_OU_SECRETARIO")]
        public OkResult Remover([FromRoute] int id)
        {
            _servicoVotacao.Remover(id);
            return Ok();
        }
    }
}
