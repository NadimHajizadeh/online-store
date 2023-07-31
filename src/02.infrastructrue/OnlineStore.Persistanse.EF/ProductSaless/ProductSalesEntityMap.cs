using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities;

namespace OnlineStore.Persistanse.EF.ProductSaless;

public class ProductSalesEntityMap : IEntityTypeConfiguration<ProductSales>
{
    public void Configure(EntityTypeBuilder<ProductSales> _)
    {
        _.ToTable("ProductSales");
        _.HasKey(_=>_.FactorNumber);
        _.Property(_ => _.CustomerName)
            .IsRequired()
            .HasMaxLength(50);
        _.Property(_ => _.Date).IsRequired();
        _.Property(_ => _.PricePerProduct).IsRequired();
        _.Property(_ => _.Count).IsRequired();
        _.Property(_ => _.ProductId).IsRequired();
    }
}