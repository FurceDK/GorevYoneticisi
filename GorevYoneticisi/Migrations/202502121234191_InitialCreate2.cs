namespace GorevYoneticisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kullanicis", "UserEmail", c => c.String(nullable: false));
            AddColumn("dbo.Kullanicis", "UserPassword", c => c.String(nullable: false));
            AddColumn("dbo.Kullanicis", "UserRank", c => c.Int(nullable: false));
            DropColumn("dbo.Kullanicis", "Email");
            DropColumn("dbo.Kullanicis", "Password");
            DropColumn("dbo.Kullanicis", "Rank");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Kullanicis", "Rank", c => c.Int(nullable: false));
            AddColumn("dbo.Kullanicis", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Kullanicis", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Kullanicis", "UserRank");
            DropColumn("dbo.Kullanicis", "UserPassword");
            DropColumn("dbo.Kullanicis", "UserEmail");
        }
    }
}
