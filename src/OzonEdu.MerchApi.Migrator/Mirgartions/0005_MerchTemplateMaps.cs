using FluentMigrator;
using FluentMigrator.Builders.Create;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(5)]
    public class MerchTemplateMaps : Migration 
    {
        public override void Up()
        {
            Create
                .Table("merch_template")
                .WithColumn("merch_type_id").AsInt64().PrimaryKey()
                .WithColumn("item_type_id").AsInt64().PrimaryKey()
                .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_template");
        }
    }
}