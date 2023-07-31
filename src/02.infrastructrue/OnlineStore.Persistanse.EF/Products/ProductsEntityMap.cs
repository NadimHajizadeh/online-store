using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities;

namespace OnlineStore.Persistanse.EF.Products;

public class ProductsEntityMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> _)
    {
        _.ToTable("Products");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).ValueGeneratedOnAdd();
        _.Property(_ => _.Title).HasMaxLength(50).IsRequired();
        _.Property(_ => _.LeastCount).IsRequired();
        _.Property(_ => _.Status).IsRequired();
        _.Property(_ => _.Count).IsRequired();
        _.Property(_ => _.ProductGroupId);

        _.HasOne(_ => _.ProductGroup)
            .WithMany(_ => _.Products)
            .HasForeignKey(_ => _.ProductGroupId);
    }
}