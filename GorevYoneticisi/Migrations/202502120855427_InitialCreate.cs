namespace GorevYoneticisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gorevs",
                c => new
                    {
                        GorevID = c.Int(nullable: false, identity: true),
                        GorevAdi = c.String(nullable: false),
                        Aciklama = c.String(),
                        Durum = c.String(nullable: false),
                        DueDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.GorevID);
            
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserSurname = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Rank = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicis");
            DropTable("dbo.Gorevs");
        }
    }
}
