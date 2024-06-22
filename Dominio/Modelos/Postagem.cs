using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Postagem
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public List<Comentario>? Comentarios { get; set;}
        public CategoriaPostagemEnum Categoria {  get; set; }
        public int UsuarioId {  get; set; }
    }
}
