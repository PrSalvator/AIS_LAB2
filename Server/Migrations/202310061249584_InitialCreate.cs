namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumberOfDoors = c.Int(nullable: false),
                        AmountOfHorsepower = c.Int(nullable: false),
                        CarBrand = c.String(),
                        CarModel = c.String(),
                        IsElectricCar = c.Boolean(nullable: false),
                        CarTypeId = c.Guid(),
                        BodyTypeId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BodyTypes", t => t.BodyTypeId)
                .ForeignKey("dbo.CarTypes", t => t.CarTypeId)
                .Index(t => t.CarTypeId)
                .Index(t => t.BodyTypeId);
            
            CreateTable(
                "dbo.CarTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarTypeId", "dbo.CarTypes");
            DropForeignKey("dbo.Cars", "BodyTypeId", "dbo.BodyTypes");
            DropIndex("dbo.Cars", new[] { "BodyTypeId" });
            DropIndex("dbo.Cars", new[] { "CarTypeId" });
            DropTable("dbo.CarTypes");
            DropTable("dbo.Cars");
            DropTable("dbo.BodyTypes");
        }
    }
}
