using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositorios
{
    public class OpcaoDeVotoRepository(CondoLifeContext condoLifeContext) : IRepository<OpcaoDeVoto>
    {
        private readonly CondoLifeContext _condoLifeContext = condoLifeContext;

        public void Adicionar(OpcaoDeVoto opcaoDeVoto)
        {
            _condoLifeContext.Add(opcaoDeVoto);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(OpcaoDeVoto opcaoDeVoto)
        {
            var opcaoDeVotoNoBanco = ObterPorId(opcaoDeVoto.Id);
            _condoLifeContext
                .Attach(opcaoDeVotoNoBanco)
                .CurrentValues
                .SetValues(opcaoDeVoto);

            _condoLifeContext.SaveChanges();
        }

        public OpcaoDeVoto ObterPorId(int id)
        {
            return _condoLifeContext
                .OpcaoDeVoto
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Opção de voto não encontrada.");
        }

        public List<OpcaoDeVoto>? ObterTodos()
        {
            return _condoLifeContext
                .OpcaoDeVoto
                .AsNoTracking()
                .ToList();
        }


        public void Remover(int id)
        {
            var opcaoDeVoto = ObterPorId(id);
            _condoLifeContext.Remove(opcaoDeVoto);
            _condoLifeContext.SaveChanges();
        }
    }
}
