namespace AGAT.LocoDispatcher.AuthDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createStationDependencyToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "StationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "StationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "StationId" });
            DropColumn("dbo.Users", "StationId");
        }
    }
}
