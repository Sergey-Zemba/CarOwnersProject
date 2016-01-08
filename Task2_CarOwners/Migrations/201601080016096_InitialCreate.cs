namespace Task2_CarOwners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarBrand = c.String(),
                        CarModel = c.String(),
                        CarType = c.String(),
                        Price = c.Int(),
                        YearOfManufacture = c.Int(),
                        Number = c.String(nullable: false, maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Owners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        YearOfBirth = c.Int(nullable: false),
                        DrivingExperience = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OwnerCars",
                c => new
                    {
                        OwnerId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OwnerId, t.CarId })
                .ForeignKey("dbo.Owners", t => t.OwnerId)
                .ForeignKey("dbo.Cars", t => t.CarId)
                .Index(t => t.OwnerId)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.OwnerCars", "OwnerId", "dbo.Owners");
            DropIndex("dbo.OwnerCars", new[] { "CarId" });
            DropIndex("dbo.OwnerCars", new[] { "OwnerId" });
            DropTable("dbo.OwnerCars");
            DropTable("dbo.Owners");
            DropTable("dbo.Cars");
        }
    }
}
