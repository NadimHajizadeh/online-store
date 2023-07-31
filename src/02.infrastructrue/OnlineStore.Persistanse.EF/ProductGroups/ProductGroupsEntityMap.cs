using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities;

namespace OnlineStore.Persistanse.EF.ProductGroups;

public class ProductGroupsEntityMap : IEntityTypeConfiguration<ProductGroup>
{
    public void Configure(EntityTypeBuilder<ProductGroup> _)
    {
        _.ToTable("ProductGroups");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).ValueGeneratedOnAdd();
        _.Property(_ => _.Name)
            .HasMaxLength(50)
            .IsRequired();
    }
    

}