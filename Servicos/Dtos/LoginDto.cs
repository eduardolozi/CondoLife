namespace Aplicacao.Dtos;

public class LoginDto
{
    public required string NomeOuEmail { get; set; }
    public required string Senha { get; set; }
}