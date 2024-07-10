using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class OpcaoDeVoto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Voto> Votos { get; set; }
        public int VotacaoId {  get; set; }
        public Votacao Votacao { get; set; }
    }
}
