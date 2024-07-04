using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class VotacaoService(IVotacaoRepository repositorioVotacao)
    {
        private readonly IVotacaoRepository _repositorioVotacao = repositorioVotacao;

        public void Adicionar(VotacaoDto votacaoDto)
        {
            try
            {
                var votacao = new Votacao
                {
                    Id = 0,
                    DataFinal = votacaoDto.DataFinal,
                    DataInicio = votacaoDto.DataInicio,
                    Descricao = votacaoDto.Descricao,
                    Opcoes = votacaoDto.Opcoes,
                    Titulo = votacaoDto.Titulo
                };
                _repositorioVotacao.Adicionar(votacao);
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
                    Opcoes = votacaoDto.Opcoes,
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
