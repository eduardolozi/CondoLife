using Aplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Testes.TesteServicoCriptografia
{
    public class teste_servico_criptografia : TesteBase
    {
        private readonly CriptografiaService _servicoCriptografia;
        public teste_servico_criptografia()
        {
            _servicoCriptografia = _serviceProvider.GetService<CriptografiaService>()
                ?? throw new Exception("CriptografiaService não foi encontrado.");
        }

        [Fact]
        public void AoCriptografarSenhaDeveRetornarArrayDeBytesNaoNulo()
        {
            var senha = "kldjhfdsf124@!";
            var chave = new byte[32];
            var iv = new byte[16];
            RandomNumberGenerator.Fill(chave);
            RandomNumberGenerator.Fill(iv);

            var senhaCriptografada = _servicoCriptografia.Criptografar(senha, chave, iv);
            Assert.IsType<byte[]>(senhaCriptografada);
            Assert.NotNull(senhaCriptografada);
        }

        [Fact]
        public void AoDescriptografarSenhaDeveBaterComSenhaOriginal()
        {
            var senha = "kldjhfdsf124@!";
            var chave = new byte[32];
            var iv = new byte[16];
            RandomNumberGenerator.Fill(chave);
            RandomNumberGenerator.Fill(iv);

            var senhaCriptografada = _servicoCriptografia.Criptografar(senha, chave, iv);
            var senhaDescriptograda = _servicoCriptografia.Descriptografar(senhaCriptografada, chave, iv);
            Assert.Equal(senha, senhaDescriptograda);
        }

    }
}
