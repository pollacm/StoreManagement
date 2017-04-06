namespace StoreManagement.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoreEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        StoreID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zipcode = c.String(),
                    })
                .PrimaryKey(t => t.StoreID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Store");
        }
    }
}
