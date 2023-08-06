using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Entities;

namespace OnlineStore.Persistanse.EF.AccountingDocuments;

public class
    AccountingDocumentEntityMap : IEntityTypeConfiguration<AccountingDocument>
{
    public void Configure(EntityTypeBuilder<AccountingDocument> _)
    {
        _.ToTable("AccountingDocuments");
        _.HasKey(_ => _.Id);
        _.Property(_ => _.Id).ValueGeneratedOnAdd();
        _.Property(_ => _.DocumentNumber).IsRequired();
        _.Property(_ => _.date).IsRequired();
        _.Property(_ => _.TotalPrice).IsRequired();
        _.Property(_ => _.SalesFactorNumber).IsRequired();
        _.HasOne(_ => _.ProductSales)
            .WithOne()
            .HasForeignKey<AccountingDocument>(_ => _.SalesFactorNumber);
    }
}