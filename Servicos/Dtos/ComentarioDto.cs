
namespace Aplicacao.Dtos
{
    public class ComentarioDto
    {
        public string Mensagem { get; set; }
        public string? Foto { get; set; }
        public int UsuarioId { get; set; }
        public int PostagemId { get; set; }
    }
}
