using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(9)]
    public class FillTemplates : ForwardOnlyMigration 
    {
        public override void Up()
        {
            FillItemSku();
            FillMerchTemplates();

        }

        private void FillItemSku()
        {
            Execute.Sql(@"
                INSERT INTO item_type_sku (item_type_id, option_id, sku_id)
                VALUES 
                    (1, 2, 141),
                    (1, 3, 142),
                    (2, 4, 151),
                    (2, 5, 152),
                    (2, 6, 153),
                    (2, 7, 154),                    
                    (3, 8, 101),
                    (3, 9, 102),
                    (3, 10, 103),                       
                    (4, 8, 111),
                    (4, 9, 112),
                    (4, 10, 113),                    
                    (5, 2, 121),
                    (5, 3, 122),                       
                    (6, 2, 131),
                    (6, 3, 132),                       
                    (7, 1, 1001),
                    (7, 12, 1002),
                    (7, 13, 1003)                    
                ON CONFLICT DO NOTHING
            ");
        }

        private void FillMerchTemplates()
        {
            Execute.Sql(@"
                INSERT INTO merch_template (merch_type_id, item_type_id, quantity)
                VALUES 
                    (10, 1, 2),                                           
                    (20, 4, 1),
                    (20, 6, 1),                       
                    (30, 4, 1),
                    (30, 5, 2),                       
                    (40, 2, 1),
                    (40, 3, 2),                       
                    (50, 7, 1)
                    
                ON CONFLICT DO NOTHING
            ");
        }
    }
}