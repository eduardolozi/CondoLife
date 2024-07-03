using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class ComentarioRepository(CondoLifeContext condoLifeContext) : IComentarioRepository
    {
        private readonly CondoLifeContext _condoLifeContext = condoLifeContext;

        public void Adicionar(Comentario comentario)
        {
            _condoLifeContext.Add(comentario);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Comentario comentario)
        {
            var comentarioNoBanco = ObterPorId(comentario.Id);
            _condoLifeContext
                .Attach(comentarioNoBanco)
                .CurrentValues
                .SetValues(comentario);
            _condoLifeContext.SaveChanges();
        }

        public Comentario ObterPorId(int id)
        {
            return _condoLifeContext
                .Comentarios
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Comentário não encontrado.");
        }

        public List<Comentario>? ObterTodos()
        {
            return _condoLifeContext
                .Comentarios
                .AsNoTracking()
                .ToList();
        }

        public List<Comentario>? ObterComentariosDaPostagem(int idPostagem)
        {
            return _condoLifeContext
                .Comentarios
                .AsNoTracking()
                .Where(x => x.PostagemId == idPostagem)
                .ToList();
        }

        public void Remover(int id)
        {
            var comentario = ObterPorId(id);
            _condoLifeContext.Remove(comentario);
            _condoLifeContext.SaveChanges();
        }
    }
}
