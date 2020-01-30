namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hh : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "Destination_id", "dbo.Destinations");
            DropIndex("dbo.Reviews", new[] { "Destination_id" });
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Destination_id", c => c.Int());
            CreateIndex("dbo.Reviews", "Destination_id");
            AddForeignKey("dbo.Reviews", "Destination_id", "dbo.Destinations", "id");
        }
    }
}
