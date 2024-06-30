using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly CondoLifeContext _condoLifeContext;
        public PostagemRepository(CondoLifeContext condoLifeContext) 
        {
            _condoLifeContext = condoLifeContext;
        }

        public void Adicionar(Postagem postagem)
        {
            _condoLifeContext.Add(postagem);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Postagem postagem)
        {
            var postagemNoBanco = ObterPorId(postagem.Id);
            _condoLifeContext
                .Attach(postagemNoBanco)
                .CurrentValues
                .SetValues(postagem);

            _condoLifeContext.SaveChanges();
        }

        public Postagem ObterPorId(int id)
        {
            return _condoLifeContext
                .Postagens
                .AsNoTracking()
                .First(x => x.Id == id)
                ?? throw new Exception("Postagem não encontrada.");
        }

        public List<Postagem> ObterTodos()
        {
            return _condoLifeContext
                .Postagens
                .AsNoTracking()
                .ToList();
        }

        public void Remover(int id)
        {
            var postagem = ObterPorId(id);
            _condoLifeContext.Remove(postagem);
            _condoLifeContext.SaveChanges();
        }
    }
}
