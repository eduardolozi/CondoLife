using Aplicacao.Servicos;
using Dominio.Enums;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Testes.Testes
{
    public class teste_servico_de_token : TesteBase
    {
        private readonly TokenService _tokenService;
        public teste_servico_de_token()
        {
            _tokenService = _serviceProvider.GetService<TokenService>() ?? throw new Exception("Não foi possível encontrar o TokenService.");
        }

        private Usuario ObterUsuario()
        {
            return new Usuario
            {
                Id = 1,
                Apartamento = 102,
                Bloco = 'C',
                Email = "alejandro@gmail.com",
                Foto = null,
                Nome = "Alejandro",
                TipoDeUsuario = TipoDeUsuarioEnum.Sindico,
                Senha = "AlgumaSenha123#"
            };
        }

        [Fact]
        public void GeraTokenValido()
        {
            var usuario = ObterUsuario();
            const string Chave = "SDI23894GFWGFYGDF&%$*#JKDHFSHGDFYGDF_2387ENSDJ";

            var token = _tokenService.GerarToken(usuario);

            var parametros = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Chave)),
                ValidIssuer = "CondoLife",
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = "CondoLife"
            };

            var handler = new JwtSecurityTokenHandler();
            handler.ValidateToken(token, parametros, out var validatedToken);
            Assert.NotNull(validatedToken);
        }

        [Fact]
        public void DeveExtourar_SecurityTokenSignatureKeyNotFoundException_AoPassarKeyErradaAoIssuerSigning()
        {
            var usuario = ObterUsuario();
            const string ChaveErrada = "JKDHFSHGDFYGDF_2387ENSDJidfuisyfusdy2323++";

            var token = _tokenService.GerarToken(usuario);

            var parametros = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ChaveErrada)),
                ValidIssuer = "CondoLife",
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateAudience = true,
                ValidAudience = "CondoLife"
            };

            var handler = new JwtSecurityTokenHandler();
            Assert.Throws<SecurityTokenSignatureKeyNotFoundException>(() => handler.ValidateToken(token, parametros, out var validatedToken));
        }
    }
}
