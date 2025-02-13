namespace GorevYoneticisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kullanicis", "Rank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kullanicis", "Rank", c => c.String(nullable: false));
        }
    }
}
