namespace Task2_CarOwners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OwnerCars", "OwnerId", "dbo.Owners");
            DropForeignKey("dbo.OwnerCars", "CarId", "dbo.Cars");
            AddForeignKey("dbo.OwnerCars", "OwnerId", "dbo.Owners", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OwnerCars", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OwnerCars", "CarId", "dbo.Cars");
            DropForeignKey("dbo.OwnerCars", "OwnerId", "dbo.Owners");
            AddForeignKey("dbo.OwnerCars", "CarId", "dbo.Cars", "Id");
            AddForeignKey("dbo.OwnerCars", "OwnerId", "dbo.Owners", "Id");
        }
    }
}
