using Dominio.Interfaces;
using Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class BoletoService(IBoletoRepository repositorioBoleto)
    {
        private readonly IBoletoRepository _repositorioBoleto = repositorioBoleto;

        public void Adicionar(Boleto boleto)
        {
            try
            {
                _repositorioBoleto.Adicionar(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, Boleto boleto)
        {
            try
            {
                boleto.Id = id;
                _repositorioBoleto.Editar(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Boleto? ObterPorId(int id)
        {
            try
            {
                return _repositorioBoleto.ObterPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Boleto>? ObterBoletosDoUsuario(int idUsuario)
        {
            try
            {
                return _repositorioBoleto.ObterBoletosDoUsuario(idUsuario);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Boleto>? ObterTodos()
        {
            try
            {
                return _repositorioBoleto.ObterTodos();
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
                _repositorioBoleto.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
