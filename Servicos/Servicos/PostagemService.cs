using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class PostagemService(IPostagemRepository postagemRepository)
    {
        private readonly IPostagemRepository _postagemRepository = postagemRepository;

        public void Adicionar(PostagemDto postagemDto)
        {
            try
            {
                var postagem = new Postagem
                {
                    Id = 0,
                    Categoria = postagemDto.Categoria,
                    Descricao = postagemDto.Descricao,
                    Foto = postagemDto.Foto,
                    Likes = postagemDto.Likes,
                    Titulo = postagemDto.Titulo,
                    UsuarioId = postagemDto.UsuarioId
                };
                _postagemRepository.Adicionar(postagem);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, PostagemDto postagemDto)
        {
            try
            {
                var postagem = new Postagem
                {
                    Id = id,
                    Categoria = postagemDto.Categoria,
                    Descricao = postagemDto.Descricao,
                    Foto = postagemDto.Foto,
                    Likes = postagemDto.Likes,
                    Titulo = postagemDto.Titulo,
                    UsuarioId = postagemDto.UsuarioId
                };
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
