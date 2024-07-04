using Dominio.Interfaces;
using Dominio.Modelos;
using Web.Dtos;

namespace Aplicacao.Servicos
{
    public class BoletoService(IBoletoRepository repositorioBoleto)
    {
        private readonly IBoletoRepository _repositorioBoleto = repositorioBoleto;

        public void Adicionar(BoletoDto boletoDto)
        {
            try
            {
                var boleto = new Boleto
                {
                    Id = 0,
                    Arquivo = boletoDto.Arquivo,
                    DataEmissao = boletoDto.DataEmissao,
                    DataVencimento = boletoDto.DataVencimento,
                    FoiPago = boletoDto.FoiPago,
                    Preco = boletoDto.Preco,
                    UsuarioId = boletoDto.UsuarioId
                };
                _repositorioBoleto.Adicionar(boleto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, BoletoDto boletoDto)
        {
            try
            {
                var boleto = new Boleto
                {
                    Id = id,
                    Arquivo = boletoDto.Arquivo,
                    DataEmissao = boletoDto.DataEmissao,
                    DataVencimento = boletoDto.DataVencimento,
                    FoiPago = boletoDto.FoiPago,
                    Preco = boletoDto.Preco,
                    UsuarioId = boletoDto.UsuarioId
                };
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
