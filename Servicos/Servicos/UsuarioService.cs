using System.Security.Cryptography;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class UsuarioService(IUsuarioRepository repositorioUsuario,
        CriptografiaService criptografiaService)
    {
        private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;
        private readonly CriptografiaService _criptografiaService = criptografiaService;

        public void Adicionar(Usuario usuario)
        {
            try
            {
                var chave = new byte[32];
                var iv = new byte[16];
                RandomNumberGenerator.Fill(chave);
                RandomNumberGenerator.Fill(iv);
                
                var senhaCriptogradada = _criptografiaService.Criptografar(usuario.Senha, chave, iv);
                usuario.Senha = Convert.ToBase64String(senhaCriptogradada);
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
