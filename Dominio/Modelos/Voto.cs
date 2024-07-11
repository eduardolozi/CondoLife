using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Modelos
{
    [NotMapped]
    public class Voto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int OpcaoDeVotoId { get; set; }
        public OpcaoDeVoto OpcaoDeVoto { get; set; }
    }
}
