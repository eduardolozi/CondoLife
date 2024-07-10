namespace Dominio.Modelos
{
    public class Votacao
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; } 
        public List<OpcaoDeVoto> OpcoesDeVoto {  get; set; }
    }
}
