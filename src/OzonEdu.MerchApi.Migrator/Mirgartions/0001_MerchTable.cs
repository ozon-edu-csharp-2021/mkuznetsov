using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(1)]
    public class MerchTable : Migration 
    {
        public override void Up()
        {
            Create
                .Table("merches")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("type_id").AsInt64().NotNullable()
                .WithColumn("merch_status").AsInt64().NotNullable()
                .WithColumn("employee_id").AsInt64().NotNullable()
                .WithColumn("issue_date").AsDate().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("merches");
        }
    }
}