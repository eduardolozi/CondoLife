using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;
using System.Text.Json;

namespace Aplicacao.Servicos
{
    public class VotacaoService(IVotacaoRepository repositorioVotacao, ProducerService producerService)
    {
        private readonly IVotacaoRepository _repositorioVotacao = repositorioVotacao;
        private readonly ProducerService _producerService = producerService;
        public async Task Adicionar(VotacaoDto votacaoDto)
        {
            try
            {
                var votacao = new Votacao
                {
                    Id = 0,
                    DataFinal = votacaoDto.DataFinal,
                    DataInicio = votacaoDto.DataInicio,
                    Descricao = votacaoDto.Descricao,
                    Titulo = votacaoDto.Titulo
                };
                var mensagem = JsonSerializer.Serialize(votacao);
                await _producerService.EnviarMensagem(mensagem);
                //_repositorioVotacao.Adicionar(votacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, VotacaoDto votacaoDto)
        {
            try
            {
                var votacao = new Votacao
                {
                    Id = id,
                    DataFinal = votacaoDto.DataFinal,
                    DataInicio = votacaoDto.DataInicio,
                    Descricao = votacaoDto.Descricao,
                    Titulo = votacaoDto.Titulo
                };
                _repositorioVotacao.Editar(votacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Votacao? ObterPorId(int id)
        {
            try
            {
                return _repositorioVotacao.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Votacao>? ObterTodos()
        {
            try
            {
                return _repositorioVotacao.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Remover(int id)
        {
            try
            {
                _repositorioVotacao.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
