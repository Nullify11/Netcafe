namespace Netcafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookingModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Computer_Id", "dbo.Computers");
            DropIndex("dbo.Bookings", new[] { "Computer_Id" });
            RenameColumn(table: "dbo.Bookings", name: "User_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.Bookings", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            AddColumn("dbo.Bookings", "UserId", c => c.String());
            AddColumn("dbo.Bookings", "ComputerId", c => c.Int(nullable: false));
            DropColumn("dbo.Bookings", "Computer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "Computer_Id", c => c.Int());
            DropColumn("dbo.Bookings", "ComputerId");
            DropColumn("dbo.Bookings", "UserId");
            RenameIndex(table: "dbo.Bookings", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Bookings", name: "ApplicationUser_Id", newName: "User_Id");
            CreateIndex("dbo.Bookings", "Computer_Id");
            AddForeignKey("dbo.Bookings", "Computer_Id", "dbo.Computers", "Id");
        }
    }
}
