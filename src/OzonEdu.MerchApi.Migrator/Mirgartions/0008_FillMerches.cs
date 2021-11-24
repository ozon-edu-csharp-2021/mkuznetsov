using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(8)]
    public class FillMerches : ForwardOnlyMigration 
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merches (id, type_id, merch_status, employee_id, issue_date)
                VALUES 
                    (1, 10, 20, 1, '2020-10-12'),
                    (2, 20, 20, 2, '2021-11-2'),
                    (3, 20, 30, 2, '2019-09-2')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO merch_sku (merch_id, sku_id, quantity)
                VALUES 
                    (1, 123, 1),
                    (1, 124, 2),
                    (3, 126, 4),
                    (3, 127, 1),
                    (3, 128, 3),
                    (3, 129, 1),
                    (2, 125, 2)
                ON CONFLICT DO NOTHING
            ");
        }
    }
}