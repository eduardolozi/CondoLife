using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public string? Foto { get; set; }
        public int UsuarioId {  get; set; }
    }
}
