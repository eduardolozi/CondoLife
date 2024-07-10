using Aplicacao.Dtos;
using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class OpcaoDeVotoService(IRepository<OpcaoDeVoto> repositorioOpcaoDeVoto)
    {
        private readonly IRepository<OpcaoDeVoto> _repositorioOpcaoDeVoto = repositorioOpcaoDeVoto;

        public void Adicionar(OpcaoDeVotoDto opcaoDeVotoDto)
        {
            try
            {
                var opcaoDeVoto = new OpcaoDeVoto
                {
                    Nome = opcaoDeVotoDto.Nome,
                    VotacaoId = opcaoDeVotoDto.VotacaoId
                };
                _repositorioOpcaoDeVoto.Adicionar(opcaoDeVoto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, OpcaoDeVotoDto opcaoDeVotoDto)
        {
            try
            {
                var opcaoDeVoto = new OpcaoDeVoto
                {
                    Id = id,
                    Nome = opcaoDeVotoDto.Nome,
                    VotacaoId = opcaoDeVotoDto.VotacaoId
                };
                _repositorioOpcaoDeVoto.Editar(opcaoDeVoto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public OpcaoDeVoto? ObterPorId(int id)
        {
            try
            {
                return _repositorioOpcaoDeVoto.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<OpcaoDeVoto>? ObterTodos()
        {
            try
            {
                return _repositorioOpcaoDeVoto.ObterTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void Remover(int id)
        {
            try
            {
                _repositorioOpcaoDeVoto.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
