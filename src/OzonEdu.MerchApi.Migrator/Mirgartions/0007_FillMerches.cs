using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(7)]
    public class FillMerches : ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merches (type_id, merch_status, employee_id, issue_date)
                VALUES 
                    (10, 20, 1, '2020-10-12'),
                    (20, 20, 2, '2021-11-2'),
                    (20, 30, 2, '2019-09-2')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}