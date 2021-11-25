using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(4)]
    public class ItemOptionsTable : Migration 
    {
        public override void Up()
        {
            Create
                .Table("item_options")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_options");
        }
    }
}