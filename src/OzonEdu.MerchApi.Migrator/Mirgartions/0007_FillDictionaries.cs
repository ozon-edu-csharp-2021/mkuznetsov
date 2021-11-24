using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(7)]
    public class FillDictionaries : ForwardOnlyMigration 
    {
        public override void Up()
        {
            FillMerchTypes();
            FillItemTypes();
            FillItemOptions();
        }

        private void FillMerchTypes()
        {
            Execute.Sql(@"
                INSERT INTO merch_types (id, name)
                VALUES 
                    (10, 'WelcomePack'),
                    (20, 'ConferenceListenerPack'),
                    (30, 'ConferenceSpeakerPack'),
                    (40, 'ProbationPeriodEndingPack'),
                    (50, 'VeteranPack')
                ON CONFLICT DO NOTHING
            ");
        }
        private void FillItemTypes()
        {
            Execute.Sql(@"
                INSERT INTO item_types (id, name)
                VALUES 
                    (1, 'pen'),
                    (2, 'cup'),
                    (3, 't-shirt'),
                    (4, 'hoodie'),
                    (5, 'earplug'),
                    (6, 'mouthguard'),
                    (7, 'car')
                ON CONFLICT DO NOTHING
            ");
        }
        
        private void FillItemOptions()
        {
            Execute.Sql(@"
                INSERT INTO item_options (id, item_type_id, description)
                VALUES 
                    (1, 1, 'small'),
                    (2, 1, 'big'),
                    (3, 2, 'white'),
                    (4, 2, 'black'),
                    (5, 2, 'green'),
                    (6, 2, 'red'),
                    (7, 3, 's'),
                    (8, 3, 'm'),
                    (9, 3, 'l'),
                    (10, 4, 's'),
                    (11, 4, 'm'),
                    (12, 4, 'l'),
                    (13, 5, 'small'),
                    (14, 5, 'big'),
                    (15, 6, 'small'),
                    (16, 6, 'big'),
                    (17, 7, 'toyota camry'),
                    (18, 7, 'subaru impreza'),
                    (19, 7, 'suzuki escudo')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}