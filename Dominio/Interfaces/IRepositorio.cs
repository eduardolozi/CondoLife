namespace Dominio.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        public void Adicionar(T objeto);
        public void Editar(T objeto);
        public void Remover(int id);
        public void ObterTodos();
        public void ObterPorId(int id);
    }
}
