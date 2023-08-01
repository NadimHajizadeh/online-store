using FluentMigrator;

namespace OnlineStore.Migrations.Migrations;
[Migration(202307302134)]
public class _202307302134_AddedProductSalesTable : Migration
{
    public override void Up()
    {
        Create.Table("ProductSales")
            .WithColumn("FactorNumber").AsGuid().PrimaryKey()
            .WithColumn("CustomerName").AsString(50).NotNullable()
            .WithColumn("Date").AsDateTime().NotNullable()
            .WithColumn("ProductId").AsInt32().NotNullable()
            .WithColumn("Count").AsInt32().NotNullable()
            .WithColumn("PricePerProduct").AsDouble().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("ProductSales");
    }
}