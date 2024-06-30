using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class VotacaoService(IVotacaoRepository repositorioVotacao)
    {
        private readonly IVotacaoRepository _repositorioVotacao = repositorioVotacao;

        public void Adicionar(Votacao votacao)
        {
            try
            {
                _repositorioVotacao.Adicionar(votacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Votacao votacao)
        {
            try
            {
                votacao.Id = id;
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
