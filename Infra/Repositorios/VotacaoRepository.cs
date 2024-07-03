using Dominio.Interfaces;
using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositorios
{
    public class VotacaoRepository(CondoLifeContext condoLifeContext) : IVotacaoRepository
    {
        private readonly CondoLifeContext _condoLifeContext = condoLifeContext;

        public void Adicionar(Votacao votacao)
        {
            _condoLifeContext.Add(votacao);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Votacao votacao)
        {
            var votacaoNoBanco = ObterPorId(votacao.Id);
            _condoLifeContext
                .Attach(votacaoNoBanco)
                .CurrentValues
                .SetValues(votacao);
            _condoLifeContext.SaveChanges();
        }

        public Votacao ObterPorId(int id)
        {
            return _condoLifeContext
                .Votacoes
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id)
                ?? throw new Exception("Votação não encontrada.");
        }

        public List<Votacao>? ObterTodos()
        {
            return _condoLifeContext
                .Votacoes
                .AsNoTracking()
                .ToList();
        }

        public void Remover(int id)
        {
            var votacao = ObterPorId(id);
            _condoLifeContext.Remove(votacao);
            _condoLifeContext.SaveChanges();
        }
    }
}
