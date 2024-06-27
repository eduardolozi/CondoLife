using Dominio.Modelos;

namespace Dominio.Interfaces
{
    public interface IBoletoRepository : IRepository<Boleto>
    {
        public List<Boleto> ObterBoletosDoUsuario(int idUsuario);
    }
}
