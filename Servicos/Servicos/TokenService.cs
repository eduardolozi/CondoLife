using Aplicacao.Dtos;
using Dominio.Modelos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Aplicacao.Servicos;

public class TokenService
{
    public string GerarToken(Usuario usuario)
    {
        var tokenDescriptor = new SecurityTokenDescriptor{
            Expires = DateTime.Now.AddDays(1),
            Issuer = "CondoLife",
            Audience = "CondoLife",
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SDI23894GFWGFYGDF&%$*#JKDHFSHGDFYGDF_2387ENSDJ")),
                SecurityAlgorithms.HmacSha256Signature),
        };

        var claims = new Claim[]
        {
            new Claim("name", usuario.Nome),
            new Claim("email", usuario.Email),
            new Claim("apartamento", usuario.Apartamento.ToString()),
            new Claim("bloco", usuario.Bloco.ToString()),
            new Claim("tipo_de_usuario", usuario.TipoDeUsuario.ToString()),

        };
        tokenDescriptor.Subject = new ClaimsIdentity(claims);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}