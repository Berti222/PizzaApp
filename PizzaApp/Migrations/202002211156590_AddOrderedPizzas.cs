namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderedPizzas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderedPizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PizzaId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        PizzaName = c.String(),
                        Price = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Pizzas", t => t.PizzaId, cascadeDelete: true)
                .Index(t => t.PizzaId)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderedPizzas", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.OrderedPizzas", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderedPizzas", new[] { "OrderId" });
            DropIndex("dbo.OrderedPizzas", new[] { "PizzaId" });
            DropTable("dbo.OrderedPizzas");
        }
    }
}
