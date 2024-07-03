using System.Security.Cryptography;
using Aplicacao;
using Aplicacao.Servicos;
using Dominio;
using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CondoLifeContext _condoLifeContext;
        private readonly CriptografiaService _criptografiaService;
        public UsuarioRepository(CondoLifeContext condoLifeContext, CriptografiaService criptografiaService)
        {
            _condoLifeContext = condoLifeContext;
            _criptografiaService = criptografiaService;
        }

        public void Adicionar(Usuario usuario)
        {
            _condoLifeContext.Add(usuario);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Usuario usuario)
        {
            var usuarioNoBanco = ObterPorId(usuario.Id);
            _condoLifeContext
                .Attach(usuarioNoBanco)
                .CurrentValues
                .SetValues(usuario);

            _condoLifeContext.SaveChanges();
        }

        public Usuario ObterPorId(int id)
        {
            return _condoLifeContext
                .Usuarios
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Usuario não encontrado.");
        }

        public List<Usuario>? ObterTodos()
        {
            return _condoLifeContext
                .Usuarios
                .AsNoTracking()
                .ToList();
        }

        public Usuario ObterUsuarioPorCredenciaisDoLogin(string nomeOuEmail, string senha)
        {
            var usuarioNoBanco = _condoLifeContext
                .Usuarios
                .AsNoTracking()
                .FirstOrDefault(x => (x.Nome == nomeOuEmail || x.Email == nomeOuEmail))
                ?? throw new Exception("Usuário não encontrado.");
            
            var chave = new byte[32];
            var iv = new byte[16];
            RandomNumberGenerator.Fill(chave);
            RandomNumberGenerator.Fill(iv);
            
            var senhaEmBytes = Convert.FromBase64String(usuarioNoBanco.Senha);
            var senhaDescriptografada = _criptografiaService.Descriptografar(senhaEmBytes, chave, iv);
            if(senhaDescriptografada == senha) return usuarioNoBanco;
            throw new Exception("Senha incorreta.");
        }

        public void Remover(int id)
        {
            var usuario = ObterPorId(id);
            _condoLifeContext.Remove(usuario);
            _condoLifeContext.SaveChanges();
        }
    }
}
