namespace EventProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Tagline = c.String(),
                        Long_Description = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.Int(),
                        Age_Limit = c.Int(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DateHappening = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.EventID)
                .Index(t => t.EventID);
            
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_ID = c.Int(nullable: false),
                        Attendee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_ID, t.Attendee_ID })
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_ID, cascadeDelete: true)
                .Index(t => t.Event_ID)
                .Index(t => t.Attendee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "EventID", "dbo.Events");
            DropForeignKey("dbo.EventAttendees", "Attendee_ID", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_ID", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_ID" });
            DropIndex("dbo.EventAttendees", new[] { "Event_ID" });
            DropIndex("dbo.Cities", new[] { "EventID" });
            DropTable("dbo.EventAttendees");
            DropTable("dbo.Cities");
            DropTable("dbo.Events");
            DropTable("dbo.Attendees");
        }
    }
}
