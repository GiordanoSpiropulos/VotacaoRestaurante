using DesafioCertponto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioCertponto.Infra.Data.Mapping
{
    public class RestauranteVencedorMap : IEntityTypeConfiguration<RestauranteVencedor>
    {

        public void Configure(EntityTypeBuilder<RestauranteVencedor> builder)
        {
            builder.ToTable("RestauranteVencedor");

            builder.HasKey(prop => prop.Id);
            builder.HasOne(rv => rv.Restaurante).WithMany().HasForeignKey(rv => rv.RestauranteID);
            builder.Property(prop => prop.DataVotacao).IsRequired().HasColumnName("DataVotacao");

        }
    }
}
