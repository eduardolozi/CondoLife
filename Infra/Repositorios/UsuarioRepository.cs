using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly CondoLifeContext _condoLifeContext;
        public UsuarioRepository(CondoLifeContext condoLifeContext)
        {
            _condoLifeContext = condoLifeContext;
        }

        public void Adicionar(Usuario usuario)
        {
            _condoLifeContext.Add(usuario);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Usuario usuario)
        {
            _condoLifeContext
                .Attach(usuario)
                .CurrentValues
                .SetValues(usuario);

            _condoLifeContext.SaveChanges();
        }

        public Usuario? ObterPorId(int id)
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

        public void Remover(int id)
        {
            var usuario = ObterPorId(id)!;
            _condoLifeContext.Remove(usuario);
            _condoLifeContext.SaveChanges();
        }
    }
}
