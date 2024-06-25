using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class ModuloDeInjecaoDaInfra
    {
        private static readonly string CadeiaDeConexao = Environment.GetEnvironmentVariable("CONEXAO_BANCO") ?? throw new Exception("Erro ao ler string de conexao");
        public static void RegistrarServicos(IServiceCollection services)
        {

            services.AddDbContext<CondoLifeContext>();
        }
    }
}
