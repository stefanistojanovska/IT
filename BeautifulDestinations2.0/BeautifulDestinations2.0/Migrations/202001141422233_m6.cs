﻿namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "userId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "userId");
        }
    }
}
