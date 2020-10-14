namespace AGAT.LocoDispatcher.AuthDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removePasswordConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
        }
    }
}
