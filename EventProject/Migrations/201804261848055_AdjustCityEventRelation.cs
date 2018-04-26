namespace EventProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustCityEventRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "EventID", "dbo.Events");
            DropIndex("dbo.Cities", new[] { "EventID" });
            AddColumn("dbo.Events", "CityID", c => c.Int());
            CreateIndex("dbo.Events", "CityID");
            AddForeignKey("dbo.Events", "CityID", "dbo.Cities", "ID");
            DropColumn("dbo.Events", "City");
            DropColumn("dbo.Cities", "EventID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "EventID", c => c.Int());
            AddColumn("dbo.Events", "City", c => c.String());
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "CityID" });
            DropColumn("dbo.Events", "CityID");
            CreateIndex("dbo.Cities", "EventID");
            AddForeignKey("dbo.Cities", "EventID", "dbo.Events", "ID");
        }
    }
}
