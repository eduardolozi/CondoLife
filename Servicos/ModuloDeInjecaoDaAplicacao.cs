﻿using Aplicacao.Servicos;
using Aplicacao.Validacoes;
using Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao
{
    public class ModuloDeInjecaoDaAplicacao
    {
        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddScoped<UsuarioService>();
            services.AddScoped<BoletoService>();
            services.AddScoped<PostagemService>();
            services.AddScoped<ComentarioService>();
            services.AddScoped<VotacaoService>();
            services.AddScoped<OpcaoDeVotoService>();
            services.AddScoped<UsuarioValidator>();
            services.AddScoped<BoletoValidator>();
            services.AddScoped<PostagemValidator>();
            services.AddScoped<ComentarioValidator>();
            services.AddScoped<VotacaoValidator>();
            services.AddScoped<CriptografiaService>();
            services.AddScoped<ProducerService>();
            services.AddScoped<TokenService>();
            services.AddScoped<LoginService>();
        }
    }
}
