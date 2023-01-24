using Hex.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

namespace Hex.Infra.ConfigurationMap
{
    public class PessoaEntityConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));

            builder.HasKey((p) => p.Id);

            builder.Property((p) => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property((p) => p.Idade)
                .HasColumnName("Idade")
                .HasColumnType("int")
                .IsRequired();

            builder.Property((p) => p.TipoEstadoCivil)
                .HasColumnName("TipoEstadoCivil")
                .HasColumnType("int")
                .IsRequired();

            builder.OwnsOne((p) => p.Documento)
                .Property((c) => c.Cpf)
                .HasColumnName("Cpf")
                .HasColumnType("varchar")
                .HasMaxLength(11)
                .IsRequired();

            builder.OwnsOne((p) => p.Localidade,
                l =>
                {
                    l.Property((c) => c.Cidade)
                       .HasColumnName("Cidade")
                       .HasColumnType("varchar")
                       .HasMaxLength(50);
                    l.Property((e) => e.Estado)
                       .HasColumnName("Estado")
                       .HasColumnType("varchar")
                       .HasMaxLength(50);
                });
        }
    }
}
