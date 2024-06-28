using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class PostagemService(IPostagemRepository postagemRepository)
    {
        private readonly IPostagemRepository _postagemRepository = postagemRepository;

        public void Adicionar(Postagem postagem)
        {
            try
            {
                _postagemRepository.Adicionar(postagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Postagem postagem)
        {
            try
            {
                postagem.Id = id;
                _postagemRepository.Editar(postagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Postagem? ObterPorId(int id)
        {
            try
            {
                return _postagemRepository.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Postagem>? ObterTodos()
        {
            try
            {
                return _postagemRepository.ObterTodos();
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
                _postagemRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
