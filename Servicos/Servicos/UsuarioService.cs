using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class UsuarioService(IUsuarioRepository repositorioUsuario)
    {
        private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;

        public void Adicionar(Usuario usuario)
        {
            try
            {
                _repositorioUsuario.Adicionar(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Usuario usuario)
        {
            try
            {
                usuario.Id = id;
                _repositorioUsuario.Editar(usuario);
            }
            catch(Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

        public Usuario? ObterPorId(int id)
        {
            try
            {
                return _repositorioUsuario.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Usuario>? ObterTodos()
        {
            try
            {
                return _repositorioUsuario.ObterTodos();
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
                _repositorioUsuario.Remover(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            } 
        }
    }
}
