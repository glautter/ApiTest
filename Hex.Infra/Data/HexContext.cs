using Hex.Domain.Entities;
using Hex.Infra.ConfigurationMap;
using Microsoft.EntityFrameworkCore;

namespace Hex.Infra.Data
{
    public class HexContext : DbContext
    {
        public HexContext (DbContextOptions<HexContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaEntityConfiguration());
        }

        public DbSet<Pessoa> Pessoa { get; set; } = default!;
    }
}
