using FluentMigrator;

namespace OnlineStore.Migrations.Migrations;
[Migration(202307302115)]
public class _202307302115_AddedProductGroupsTable : Migration
{
    public override void Up()
    {
        Create.Table("ProductGroups")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable();

    }

    public override void Down()
    {
        Delete.Table("ProductGroups");
    }
}