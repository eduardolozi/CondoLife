using Dominio.Interfaces;
using Dominio.Modelos;
using Infra.Repositorios;
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
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddDbContext<CondoLifeContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IVotacaoRepository, VotacaoRepository>();
        }
    }
}
