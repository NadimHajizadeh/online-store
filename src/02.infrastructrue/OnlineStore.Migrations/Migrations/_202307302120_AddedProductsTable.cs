using FluentMigrator;

namespace OnlineStore.Migrations.Migrations;
[Migration(202307302120)]
public class _202307302120_AddedProductTable : Migration
{
    public override void Up()
    {
        Create.Table("Products")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Title").AsString(50).NotNullable()
            .WithColumn("LeastCount").AsInt32().NotNullable()
            .WithColumn("status").AsInt32().NotNullable()
            .WithColumn("Count").AsInt32()
            .WithColumn("ProductGroupId").AsInt32().NotNullable()
            .ForeignKey("FK_Products_ProductGroups", "ProductGroups", "Id");
    }

    public override void Down()
    {
        Delete.Table("Products");
    }
}