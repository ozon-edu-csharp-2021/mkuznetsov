using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(3)]
    public class ItemTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("item_types")
                .WithColumn("id").AsInt32().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("item_types");
        }
    }
}