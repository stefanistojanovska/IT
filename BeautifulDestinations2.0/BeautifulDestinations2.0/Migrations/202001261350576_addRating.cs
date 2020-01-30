namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destinations", "overallRating", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destinations", "overallRating");
        }
    }
}
