using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IComentarioRepository : IRepository<Comentario>
    {
        public List<Comentario>? ObterComentariosDaPostagem(int idPostagem);
    }
}
