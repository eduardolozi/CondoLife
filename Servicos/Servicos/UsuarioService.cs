using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class UsuarioService(
        IUsuarioRepository repositorioUsuario,
        IBoletoRepository repositorioBoleto)
    {
        private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;
        private readonly IBoletoRepository _repositorioBoleto = repositorioBoleto;

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

        public void Editar(Usuario usuario)
        {
            try
            {
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
                var usuarios = _repositorioUsuario.ObterTodos();
                foreach(var usuario in usuarios!)
                {
                    usuario.Boletos.AddRange(_repositorioBoleto.ObterBoletosDoUsuario(usuario.Id));
                }
                var x = usuarios[0].Boletos[0].Usuario;
                return usuarios;
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
