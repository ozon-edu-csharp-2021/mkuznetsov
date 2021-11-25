using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Mirgartions
{
    [Migration(8)]
    public class FillDictionaries : ForwardOnlyMigration 
    {
        public override void Up()
        {
            FillMerchTypes();
            FillItemOptions();
            FillItemTypes();
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
        
        private void FillItemOptions()
        {
            Execute.Sql(@"
                INSERT INTO item_options (id, name)
                VALUES 
                    (1, 'default'),
                    (2, 'small'),
                    (3, 'big'),
                    (4, 'white'),
                    (5, 'black'),
                    (6, 'green'),
                    (7, 'red'),
                    (8, 's'),
                    (9, 'm'),
                    (10, 'l'),
                    (11, 'camry'),
                    (12, 'impreza'),
                    (13, 'escudo')
                ON CONFLICT DO NOTHING
            ");
        }
        
        private void FillItemTypes()
        {
            Execute.Sql(@"
                INSERT INTO item_types (id, name, default_option_id)
                VALUES 
                    (1, 'pen', 2),
                    (2, 'cup', 6),
                    (3, 't-shirt', 9),
                    (4, 'hoodie', 10),
                    (5, 'earplug', 2),
                    (6, 'mouthguard', 3),
                    (7, 'car', 12)
                ON CONFLICT DO NOTHING
            ");
        }


    }
}