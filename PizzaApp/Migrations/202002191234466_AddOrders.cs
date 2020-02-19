namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GuestId = c.Int(nullable: false),
                        OrderTime = c.DateTime(nullable: false),
                        FullPrice = c.Int(nullable: false),
                        DelivererId = c.Int(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliverers", t => t.DelivererId, cascadeDelete: true)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId)
                .Index(t => t.DelivererId);
            
            AddColumn("dbo.Pizzas", "Order_Id", c => c.Int());
            CreateIndex("dbo.Pizzas", "Order_Id");
            AddForeignKey("dbo.Pizzas", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pizzas", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.Orders", "DelivererId", "dbo.Deliverers");
            DropIndex("dbo.Pizzas", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "DelivererId" });
            DropIndex("dbo.Orders", new[] { "GuestId" });
            DropColumn("dbo.Pizzas", "Order_Id");
            DropTable("dbo.Orders");
        }
    }
}
