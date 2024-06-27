namespace Dominio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public void Adicionar(T objeto);
        public void Editar(T objeto);
        public void Remover(int id);
        public List<T>? ObterTodos();
        public T? ObterPorId(int id);
    }
}
