using Microsoft.EntityFrameworkCore;
using project.domain.Entities;

namespace project.data.Configuration
{
    public interface IProductEntityFrameworkMapping
    {
        void Map(ModelBuilder builder);
    }

    public class ProductEntityFrameworkMapping : IProductEntityFrameworkMapping
    {
        public void Map(ModelBuilder builder)
        {
            builder.Entity<Product>().ToTable("Products");

            builder.Entity<Product>().HasKey(x => x.Id);

            builder.Entity<Product>().Property(x => x.Name)
                .HasColumnName("Name")
                .IsUnicode(false)
                .IsRequired();

            builder.Entity<Product>().Property(x => x.Price)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("Price")
                .IsRequired();

            builder.Entity<Product>().Property(x => x.ImageURL)
                    .HasColumnName("ImagemURL")
                    .IsUnicode(false)
                    .IsRequired();

            builder.Entity<Product>().Property(x => x.CreatedDateUtc)
                .HasColumnName("CreatedDateUtc")
                .IsRequired();

            builder.Entity<Product>().Property(x => x.LastUpdateDataUtc)
                .HasColumnName("LastUpdateDataUtc")
                .IsRequired(false);

            builder.Entity<Product>().Property(x => x.IsDeleted)
                .HasColumnName("IsDeleted")
                .HasDefaultValue<bool>(false)
                .IsRequired();

            builder.Entity<Product>().Property(x => x.DeleteDateUtc)
                .HasColumnName("DeleteDateUtc")
                .IsRequired(false);

            builder.Entity<Product>()
                .HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
