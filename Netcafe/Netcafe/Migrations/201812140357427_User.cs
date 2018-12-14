namespace Netcafe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bookings", name: "ApplicationUser_Id", newName: "User_Id");
            RenameIndex(table: "dbo.Bookings", name: "IX_ApplicationUser_Id", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Bookings", name: "IX_User_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Bookings", name: "User_Id", newName: "ApplicationUser_Id");
        }
    }
}
