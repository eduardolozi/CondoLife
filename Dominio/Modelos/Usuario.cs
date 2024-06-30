using Dominio.Enums;
using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public byte Apartamento { get; set; }
        public char? Bloco { get; set; }
        public string? Foto { get; set; }
        public TipoDeUsuarioEnum TipoDeUsuario { get; set; }
        [JsonIgnore]
        public List<Postagem>? Postagens { get; set; } = [];
        [JsonIgnore]
        public List<Comentario>? Comentarios { get; set; } = [];
        [JsonIgnore]
        public List<Boleto>? Boletos { get; set; } = [];
    }
}
