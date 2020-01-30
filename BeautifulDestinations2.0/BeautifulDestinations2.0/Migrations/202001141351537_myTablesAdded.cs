namespace BeautifulDestinations2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        Destination_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Destinations", t => t.Destination_id)
                .Index(t => t.Destination_id);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImgUrl = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Destination_id", "dbo.Destinations");
            DropIndex("dbo.Reviews", new[] { "Destination_id" });
            DropTable("dbo.Destinations");
            DropTable("dbo.Reviews");
        }
    }
}
