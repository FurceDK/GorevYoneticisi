namespace GorevYoneticisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            // 1. Yeni bir geçici sütun ekleyin
            AddColumn("dbo.Gorevs", "DurumInt", c => c.Int(nullable: false));

            // 2. Mevcut 'Durum' verilerini 'DurumInt' sütununa taşırken dönüştürün
            Sql(@"
        UPDATE dbo.Gorevs
        SET DurumInt = 
            CASE Durum
                WHEN 'Bekliyor' THEN 0
                WHEN 'Devam Ediyor' THEN 1
                WHEN 'Tamamlandı' THEN 2
                ELSE 0
            END
    ");

            // 3. Eski 'Durum' sütununu kaldırın
            DropColumn("dbo.Gorevs", "Durum");

            // 4. 'DurumInt' sütununu 'Durum' olarak yeniden adlandırın
            RenameColumn("dbo.Gorevs", "DurumInt", "Durum");
        }


        public override void Down()
        {
            // 1. Eski 'Durum' sütununu yeniden ekleyin
            AddColumn("dbo.Gorevs", "Durum", c => c.String(nullable: false));

            // 2. 'Durum' verilerini geri dönüştürün
            Sql(@"
        UPDATE dbo.Gorevs
        SET Durum = 
            CASE Durum
                WHEN 0 THEN 'Bekliyor'
                WHEN 1 THEN 'Devam Ediyor'
                WHEN 2 THEN 'Tamamlandı'
                ELSE 'Bekliyor'
            END
    ");

            // 3. 'Durum' (enum) sütununu kaldırın
            DropColumn("dbo.Gorevs", "Durum");
        }

    }
}
