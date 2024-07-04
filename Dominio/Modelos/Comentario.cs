using System.Text.Json.Serialization;

namespace Dominio.Modelos
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public string? Foto { get; set; }
        public int UsuarioId {  get; set; }
        public Usuario Usuario { get; set; }
        public int PostagemId { get; set; }
        public Postagem? Postagem { get; set; }
    }
}
