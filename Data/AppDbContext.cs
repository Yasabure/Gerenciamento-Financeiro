using GerenciamentoFinanceiro.Model;
using Microsoft.EntityFrameworkCore;
namespace GerenciamentoFinanceiro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<MetaFinanceira> MetaFinanceiras { get; set; }
        public DbSet<DespesasFixas> DespesasFixas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
