namespace GorevYoneticisi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArsivlenmeTarihiToGorev : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gorevs", "Arsivle", c => c.Boolean(nullable: false));
            AddColumn("dbo.Gorevs", "ArsivlenmeTarihi", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gorevs", "ArsivlenmeTarihi");
            DropColumn("dbo.Gorevs", "Arsivle");
        }
    }
}
