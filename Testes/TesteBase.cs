using Aplicacao;
using Microsoft.Extensions.DependencyInjection;

namespace Testes
{
    public class TesteBase : IDisposable
    {
        internal readonly ServiceProvider _serviceProvider;

        public TesteBase() 
        {
            var services = new ServiceCollection();
            ModuloDeInjecaoDaAplicacao.RegistrarServicos(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
