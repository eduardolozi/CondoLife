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
    public class BoletoRepository : IBoletoRepository
    {
        private readonly CondoLifeContext _condoLifeContext;
        public BoletoRepository(CondoLifeContext condoLifeContext) 
        {
            _condoLifeContext = condoLifeContext;
        }
        public void Adicionar(Boleto boleto)
        {
            _condoLifeContext.Add(boleto);
            _condoLifeContext.SaveChanges();
        }

        public void Editar(Boleto boleto)
        {
            var boletoNoBanco = ObterPorId(boleto.Id);
            _condoLifeContext
                .Attach(boletoNoBanco)
                .CurrentValues
                .SetValues(boleto);

            _condoLifeContext.SaveChanges();
        }

        public Boleto ObterPorId(int id)
        {
            return _condoLifeContext
                .Boletos
                .AsNoTracking()
                .First(x => x.Id == id)
                ?? throw new Exception("Boleto não encontrado.");
        }

        public List<Boleto>? ObterTodos()
        {
            return _condoLifeContext
                .Boletos
                .AsNoTracking()
                .ToList();
        }

        public List<Boleto> ObterBoletosDoUsuario(int idUsuario)
        {
            return _condoLifeContext
                .Boletos
                .AsNoTracking()
                .Where(x => x.UsuarioId ==  idUsuario)
                .ToList();
        }

        public void Remover(int id)
        {
            var boleto = ObterPorId(id);
            _condoLifeContext.Remove(boleto);
            _condoLifeContext.SaveChanges();
        }
    }
}
