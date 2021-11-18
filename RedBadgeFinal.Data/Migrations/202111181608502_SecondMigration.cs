namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "CharacterBackground", c => c.Int(nullable: false));
            DropColumn("dbo.Character", "ChracterBackground");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "ChracterBackground", c => c.Int(nullable: false));
            DropColumn("dbo.Character", "CharacterBackground");
        }
    }
}
