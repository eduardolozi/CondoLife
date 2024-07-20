using System.Security.Cryptography;
using System.Text;

namespace Aplicacao.Servicos;

public class CriptografiaService
{
    public byte[] Criptografar(string dados, byte[] chave, byte[] iv)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = chave;
            aes.IV = iv;
            var encriptador = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] bytesCriptografados;
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encriptador, CryptoStreamMode.Write))
                {
                    var dadosEmBytes = Encoding.UTF8.GetBytes(dados);
                    cs.Write(dadosEmBytes, 0, dadosEmBytes.Length);
                    cs.Flush();
                }
                bytesCriptografados = ms.ToArray();
            }
            return bytesCriptografados;
        }
    }

    public string Descriptografar(byte[] dados, byte[] chave, byte[] iv)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = chave;
            aes.IV = iv;
            var decriptador = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] bytesDescryptografados;
            using (var ms = new MemoryStream(dados))
            {
                using (var cs = new CryptoStream(ms, decriptador, CryptoStreamMode.Read))
                {
                    using (var msDecript = new MemoryStream())
                    {
                        cs.CopyTo(msDecript);
                        bytesDescryptografados = msDecript.ToArray();
                    }
                }
            }
            return Encoding.UTF8.GetString(bytesDescryptografados);
        }
    }
}