using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos;

public class LoginService(IUsuarioRepository repositorioUsuario, TokenService tokenService)
{
    private readonly TokenService _tokenService = tokenService;
    private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;

    public Usuario Login(LoginDto login)
    {
        login.Senha = login.Senha;
        var usuario = _repositorioUsuario.ObterUsuarioPorCredenciaisDoLogin(login.NomeOuEmail, login.Senha);
        var token =_tokenService.GerarToken(usuario);
        return usuario;
    }
}