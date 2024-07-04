using System.Security.Cryptography;
using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos
{
    public class UsuarioService(IUsuarioRepository repositorioUsuario,
        CriptografiaService criptografiaService)
    {
        private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;
        private readonly CriptografiaService _criptografiaService = criptografiaService;

        public void Adicionar(UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = 0,
                    Nome = usuarioDto.Nome,
                    Foto = usuarioDto.Foto,
                    Apartamento = usuarioDto.Apartamento,
                    Bloco = usuarioDto.Bloco,
                    Email = usuarioDto.Email,
                    Senha = usuarioDto.Senha,
                    TipoDeUsuario = usuarioDto.TipoDeUsuario
                };
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

        public void Editar(int id, UsuarioDto usuarioDto)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = id,
                    Nome = usuarioDto.Nome,
                    Foto = usuarioDto.Foto,
                    Apartamento = usuarioDto.Apartamento,
                    Bloco = usuarioDto.Bloco,
                    Email = usuarioDto.Email,
                    Senha = usuarioDto.Senha,
                    TipoDeUsuario = usuarioDto.TipoDeUsuario
                };
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
