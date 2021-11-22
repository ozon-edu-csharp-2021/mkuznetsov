using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(2)]
    public class MerchTypeTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("merch_types")
                .WithColumn("id").AsInt64().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merch_types");
        }
    }
}