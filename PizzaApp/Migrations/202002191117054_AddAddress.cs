namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestAddress = c.String(),
                        GusetId = c.Int(nullable: false),
                        Gueset_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guests", t => t.Gueset_Id)
                .Index(t => t.Gueset_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Gueset_Id", "dbo.Guests");
            DropIndex("dbo.Addresses", new[] { "Gueset_Id" });
            DropTable("dbo.Addresses");
        }
    }
}
