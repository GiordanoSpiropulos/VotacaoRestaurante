using DesafioCertponto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioCerponto.Infra.Data.Mapping
{
    public class VotacaoMap : IEntityTypeConfiguration<Votacao>
    {
        public void Configure(EntityTypeBuilder<Votacao> builder)
        {
            builder.ToTable("Votacao");
            builder.HasKey(prop => prop.VotacaoID);
            builder.HasOne(v => v.Profissional).WithMany().HasForeignKey(v => v.ProfissionalID);
            builder.HasOne(v => v.Restaurante).WithMany().HasForeignKey(v => v.RestauranteID);
            builder.Property(prop => prop.DataVotacao).IsRequired().HasColumnName("DataVotacao");

        }
    }
}
