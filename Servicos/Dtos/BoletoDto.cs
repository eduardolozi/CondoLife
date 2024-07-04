using Dominio.Modelos;
using System.Text.Json.Serialization;

namespace Web.Dtos
{
    public class BoletoDto
    {
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public bool FoiPago { get; set; }
        public double Preco { get; set; }
        public string? Arquivo { get; set; }
        public int UsuarioId { get; set; }
    }
}
