namespace Task2_CarOwners.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "CarBrand", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "CarModel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "CarModel", c => c.String());
            AlterColumn("dbo.Cars", "CarBrand", c => c.String());
        }
    }
}
