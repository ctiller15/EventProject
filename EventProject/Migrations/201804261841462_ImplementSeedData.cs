namespace EventProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplementSeedData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Zip", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Zip", c => c.Int());
        }
    }
}
