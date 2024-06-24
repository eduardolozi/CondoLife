using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Postagem> Postagens { get; set; } = [];
        public List<Comentario> Comentarios { get; set; } = [];
        public List<Boleto> Boletos { get; set; } = [];
    }
}
