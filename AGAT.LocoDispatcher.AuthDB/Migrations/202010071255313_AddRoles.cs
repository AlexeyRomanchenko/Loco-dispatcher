namespace AGAT.LocoDispatcher.AuthDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.Users", "Role_RoleId");
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropColumn("dbo.Users", "Role_RoleId");
            DropColumn("dbo.Users", "Password");
            DropTable("dbo.Roles");
        }
    }
}
