using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities;

namespace OnlineStore.Persistanse.EF.ProductImports;

public class ProductImportEntityMap : IEntityTypeConfiguration<ProductImport>
{
    public void Configure(EntityTypeBuilder<ProductImport> _)
    {
        _.ToTable("ProductImports");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).ValueGeneratedOnAdd();
        _.Property(_ => _.ProductId).IsRequired();
        _.Property(_ => _.Count).IsRequired();
        _.Property(_ => _.Date).IsRequired();
        _.Property(_ => _.FactorNumber).IsRequired();
        _.Property(_ => _.CompenyName).IsRequired()
            .HasMaxLength(50);
    }
}