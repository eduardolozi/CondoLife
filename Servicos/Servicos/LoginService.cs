using Dominio.Interfaces;
using Dominio.Modelos;

namespace Aplicacao.Servicos;

public class LoginService(IUsuarioRepository repositorioUsuario)
{
    private readonly IUsuarioRepository _repositorioUsuario = repositorioUsuario;

    public Usuario Login(LoginDto login)
    {
        login.Senha = login.Senha;
        var usuario = _repositorioUsuario.ObterUsuarioPorCredenciaisDoLogin(login.NomeOuEmail, login.Senha);
        return usuario;
    }
}