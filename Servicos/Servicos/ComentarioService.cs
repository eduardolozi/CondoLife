using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class ComentarioService(IComentarioRepository repositorioComentario)
    {
        private readonly IComentarioRepository _repositorioComentario = repositorioComentario;

        public void Adicionar(Comentario comentario)
        {
            try
            {
                _repositorioComentario.Adicionar(comentario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Comentario comentario)
        {
            try
            {
                comentario.Id = id;
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
