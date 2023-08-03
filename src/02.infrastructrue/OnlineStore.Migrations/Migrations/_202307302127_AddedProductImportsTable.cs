using FluentMigrator;

namespace OnlineStore.Migrations.Migrations;
[Migration(202307302127)]
public class _202307302127_AddedProductImportTable : Migration
{
    public override void Up()
    {
        Create.Table("ProductImports")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("ProductId").AsInt32().NotNullable()
            .WithColumn("CompenyName").AsString(50).NotNullable()
            .WithColumn("Count").AsInt32().NotNullable()
            .WithColumn("Date").AsDateTime2().NotNullable()
            .WithColumn("FactorNumber").AsString(50).NotNullable();
    }

    public override void Down()
    {
        Delete.Table("ProductImports");
    }
}