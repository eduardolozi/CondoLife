namespace Aplicacao.Dtos
{
    public class VotacaoDto
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Opcoes { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
