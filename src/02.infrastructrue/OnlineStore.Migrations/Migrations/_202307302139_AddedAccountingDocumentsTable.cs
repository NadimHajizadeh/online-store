using FluentMigrator;

namespace OnlineStore.Migrations.Migrations;

    [Migration(202307302139)]
public class _202307302139_AddedAccountingDocumentsTable : Migration
{
    public override void Up()
    {
        Create.Table("AccountingDocuments")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("DocumentNumber").AsInt32().NotNullable()
            .WithColumn("Date").AsDateTime().NotNullable()
            .WithColumn("TotalPrice").AsDouble().NotNullable()
            .WithColumn("SalesFactorNumber").AsGuid()
            .ForeignKey("FK_AccountingDocuments_ProductSales", "ProductSales",
                "FactorNumber");
    }

    public override void Down()
    {
        Delete.Table("AccountingDocuments");
    }
}