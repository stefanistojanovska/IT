namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userEmail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "userEmail", c => c.String());
            DropColumn("dbo.Reviews", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "userId", c => c.Int(nullable: false));
            DropColumn("dbo.Reviews", "userEmail");
        }
    }
}
