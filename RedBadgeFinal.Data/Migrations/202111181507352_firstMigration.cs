namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "CharacterName", c => c.String());
            DropColumn("dbo.Character", "ChracterName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Character", "ChracterName", c => c.String());
            DropColumn("dbo.Character", "CharacterName");
        }
    }
}
