using Dominio.Enums;

namespace Aplicacao.Dtos
{
    public class PostagemDto
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public int Likes { get; set; }
        public CategoriaPostagemEnum Categoria { get; set; }
        public int UsuarioId { get; set; }
    }
}
