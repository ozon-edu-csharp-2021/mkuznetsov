using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(6)]
    public class ItemTypeSkuMaps : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_type_sku")
                .WithColumn("item_type_id").AsInt64().PrimaryKey()
                .WithColumn("option_id").AsInt64().PrimaryKey()
                .WithColumn("sku_id").AsInt64().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_type_sku");
        }
    }
}