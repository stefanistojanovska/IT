namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "Username", c => c.String(nullable: false));
        }
    }
}
