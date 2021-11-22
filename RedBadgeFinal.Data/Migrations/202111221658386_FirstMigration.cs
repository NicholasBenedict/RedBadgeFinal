namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
           
            
            CreateTable(
                "dbo.CharacterSpell",
                c => new
                    {
                        CharacterSpellId = c.Int(nullable: false, identity: true),
                        CharacterId = c.Int(nullable: false),
                        SpellId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterSpellId)
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: false)
                .ForeignKey("dbo.Spell", t => t.SpellId, cascadeDelete: false)
                .Index(t => t.CharacterId)
                .Index(t => t.SpellId);
            
            
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CharacterSpell", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.CharacterSpell", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.Inventory", "ItemId", "dbo.ItemTypes");
            DropForeignKey("dbo.Inventory", "CharacterId", "dbo.Character");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CharacterSpell", new[] { "SpellId" });
            DropIndex("dbo.CharacterSpell", new[] { "CharacterId" });
            DropIndex("dbo.Inventory", new[] { "ItemId" });
            DropIndex("dbo.Inventory", new[] { "CharacterId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Spell");
            DropTable("dbo.CharacterSpell");
            DropTable("dbo.ItemTypes");
            DropTable("dbo.Inventory");
            DropTable("dbo.Character");
        }
    }
}
