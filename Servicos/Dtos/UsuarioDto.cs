using Dominio.Enums;
using Dominio.Modelos;

namespace Aplicacao.Dtos
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte Apartamento { get; set; }
        public char? Bloco { get; set; }
        public string? Foto { get; set; }
        public TipoDeUsuarioEnum TipoDeUsuario { get; set; }
    }
}
