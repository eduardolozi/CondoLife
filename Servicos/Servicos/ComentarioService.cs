using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class ComentarioService(IComentarioRepository repositorioComentario)
    {
        private readonly IComentarioRepository _repositorioComentario = repositorioComentario;

        public void Adicionar(ComentarioDto comentarioDto)
        {
            try
            {
                var comentario = new Comentario
                {
                    Id = 0,
                    Foto = comentarioDto.Foto,
                    Mensagem = comentarioDto.Mensagem,
                    PostagemId = comentarioDto.PostagemId,
                    UsuarioId = comentarioDto.UsuarioId,
                };
                _repositorioComentario.Adicionar(comentario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, ComentarioDto comentarioDto)
        {
            try
            {
                var comentario = new Comentario
                {
                    Id = id,
                    Foto = comentarioDto.Foto,
                    Mensagem = comentarioDto.Mensagem,
                    PostagemId = comentarioDto.PostagemId,
                    UsuarioId = comentarioDto.UsuarioId,
                };
                _repositorioComentario.Editar(comentario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Comentario? ObterPorId(int id)
        {
            try
            {
                return _repositorioComentario.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Comentario>? ObterTodos()
        {
            try
            {
                return _repositorioComentario.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Comentario>? ObterComentariosDaPostagem(int idPostagem)
        {
            try
            {
                return _repositorioComentario.ObterComentariosDaPostagem(idPostagem);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Remover(int id)
        {
            try
            {
                _repositorioComentario.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
