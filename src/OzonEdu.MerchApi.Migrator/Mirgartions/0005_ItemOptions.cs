using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(5)]
    public class ItemOptions : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_options")
                .WithColumn("id").AsInt64().PrimaryKey()
                .WithColumn("item_type_id").AsInt64().NotNullable()
                .WithColumn("description").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_options");
        }
    }
}