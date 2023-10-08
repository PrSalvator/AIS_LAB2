namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentityAndRequiredToTypesTables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BodyTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CarTypes", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarTypes", "Name", c => c.String());
            AlterColumn("dbo.BodyTypes", "Name", c => c.String());
        }
    }
}
