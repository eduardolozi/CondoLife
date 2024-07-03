using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public Usuario ObterUsuarioPorCredenciaisDoLogin(string nomeOuEmail, string senha);
    }
}
