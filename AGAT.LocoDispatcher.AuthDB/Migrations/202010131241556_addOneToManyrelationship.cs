namespace AGAT.LocoDispatcher.AuthDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOneToManyrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            RenameColumn(table: "dbo.Users", name: "Role_RoleId", newName: "RoleId");
            AlterColumn("dbo.Users", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            AlterColumn("dbo.Users", "RoleId", c => c.Int());
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_RoleId");
            CreateIndex("dbo.Users", "Role_RoleId");
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
        }
    }
}
