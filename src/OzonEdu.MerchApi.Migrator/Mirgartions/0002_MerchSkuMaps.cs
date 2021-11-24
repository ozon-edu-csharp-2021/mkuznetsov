using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(2)]
    public class MerchSkuMaps : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_sku")
                .WithColumn("merch_id").AsInt64().PrimaryKey()
                .WithColumn("sku_id").AsInt64().PrimaryKey()
                .WithColumn("quantity").AsInt32().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_sku");
        }
    }
}