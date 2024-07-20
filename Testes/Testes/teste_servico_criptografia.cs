using Aplicacao.Servicos;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Testes.TesteServicoCriptografia
{
    public class teste_servico_criptografia : TesteBase
    {
        private readonly string senha = "kldjhfdsf124@!";
        private readonly byte[] chave = new byte[32];
        private readonly byte[] iv = new byte[16];
        
        private readonly CriptografiaService _servicoCriptografia;
        
        public teste_servico_criptografia()
        {
            _servicoCriptografia = _serviceProvider.GetService<CriptografiaService>()
                ?? throw new Exception("CriptografiaService não foi encontrado.");
        }

        [Fact]
        public void AoCriptografarSenhaDeveRetornarArrayDeBytesNaoNulo()
        {
            RandomNumberGenerator.Fill(chave);
            RandomNumberGenerator.Fill(iv);
            var senhaCriptografada = _servicoCriptografia.Criptografar(senha, chave, iv);
            Assert.IsType<byte[]>(senhaCriptografada);
            Assert.NotNull(senhaCriptografada);
        }

        [Fact]
        public void AoDescriptografarSenhaDeveBaterComSenhaOriginal()
        {
            RandomNumberGenerator.Fill(chave);
            RandomNumberGenerator.Fill(iv);
            var senhaCriptografada = _servicoCriptografia.Criptografar(senha, chave, iv);
            var senhaDescriptograda = _servicoCriptografia.Descriptografar(senhaCriptografada, chave, iv);
            Assert.Equal(senha, senhaDescriptograda);
        }
    }
}
