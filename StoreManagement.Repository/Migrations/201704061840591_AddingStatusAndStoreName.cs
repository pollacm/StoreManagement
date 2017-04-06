namespace StoreManagement.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatusAndStoreName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "StoreNumber", c => c.String());
            AddColumn("dbo.Store", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "Status");
            DropColumn("dbo.Store", "StoreNumber");
        }
    }
}
