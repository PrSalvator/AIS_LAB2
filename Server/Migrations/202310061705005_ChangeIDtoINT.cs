namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeIDtoINT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes");
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropIndex("dbo.Cars", new[] { "CarTypeId" });
            DropIndex("dbo.Cars", new[] { "BodyTypeId" });
            DropPrimaryKey("dbo.BodyTypes");
            DropPrimaryKey("dbo.Cars");
            DropPrimaryKey("dbo.CarTypes");
            DropColumn("dbo.Cars", "BodyTypeId");
            DropColumn("dbo.Cars", "CarTypeId");
            DropColumn("dbo.Cars", "Id");
            DropColumn("dbo.BodyTypes", "Id");
            DropColumn("dbo.CarTypes", "Id");
            AddColumn("dbo.BodyTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cars", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cars", "CarTypeId", c => c.Int());
            AddColumn("dbo.Cars", "BodyTypeId", c => c.Int());
            AddColumn("dbo.CarTypes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BodyTypes", "Id");
            AddPrimaryKey("dbo.Cars", "Id");
            AddPrimaryKey("dbo.CarTypes", "Id");
            CreateIndex("dbo.Cars", "CarTypeId");
            CreateIndex("dbo.Cars", "BodyTypeId");
            AddForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes", "Id");
            AddForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.Cars", new[] { "BodyTypeId" });
            DropIndex("dbo.Cars", new[] { "CarTypeId" });
            DropPrimaryKey("dbo.CarTypes");
            DropPrimaryKey("dbo.Cars");
            DropPrimaryKey("dbo.BodyTypes");
            AlterColumn("dbo.CarTypes", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "BodyTypeId", c => c.Guid());
            AlterColumn("dbo.Cars", "CarTypeId", c => c.Guid());
            AlterColumn("dbo.Cars", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.BodyTypes", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.CarTypes", "Id");
            AddPrimaryKey("dbo.Cars", "Id");
            AddPrimaryKey("dbo.BodyTypes", "Id");
            CreateIndex("dbo.Cars", "BodyTypeId");
            CreateIndex("dbo.Cars", "CarTypeId");
            AddForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes", "Id");
            AddForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes", "Id");
        }
    }
}
