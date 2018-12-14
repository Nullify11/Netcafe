namespace Netcafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Computers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Computers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isOn = c.Boolean(nullable: false),
                        Performance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bookings", "Computer_Id", c => c.Int());
            CreateIndex("dbo.Bookings", "Computer_Id");
            AddForeignKey("dbo.Bookings", "Computer_Id", "dbo.Computers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.Bookings", new[] { "Computer_Id" });
            DropColumn("dbo.Bookings", "Computer_Id");
            DropTable("dbo.Computers");
        }
    }
}
