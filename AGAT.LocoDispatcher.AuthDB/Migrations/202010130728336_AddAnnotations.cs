namespace AGAT.LocoDispatcher.AuthDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "Name", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String());
        }
    }
}
