using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using project.domain.Entities;

namespace project.repository.Configuration
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");


            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(x => x.Valor)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.ImagemURL)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ImagemURL");

            builder.Ignore(x => x.Validation);
        }
    }
}
