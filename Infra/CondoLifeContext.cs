using Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class CondoLifeContext : DbContext
    {
        private readonly string ConexaoBanco = Environment.GetEnvironmentVariable("CONEXAO_BANCO") ?? throw new Exception("String de conexão não encontrada.");
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConexaoBanco);
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Votacao> Votacoes { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
    }
}
