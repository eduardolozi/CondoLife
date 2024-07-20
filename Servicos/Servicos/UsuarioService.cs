using System.Security.Cryptography;
using Aplicacao.Dtos;
using Dominio.Enums;
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
                byte[] key =
                {
                    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                };
                byte[] iv =
                {
                    0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
                    0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
                };

                var senhaCriptogradada = _criptografiaService.Criptografar(usuario.Senha, key, iv);
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
