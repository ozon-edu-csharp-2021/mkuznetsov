using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(5)]
    public class ItemTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_types")
                .WithColumn("id").AsInt64().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("default_option_id").AsInt64().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_types");
        }
    }
}