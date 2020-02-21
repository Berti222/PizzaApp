namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDeliverIdInOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DelivererId", "dbo.Deliverers");
            DropIndex("dbo.Orders", new[] { "DelivererId" });
            AlterColumn("dbo.Orders", "DelivererId", c => c.Int());
            CreateIndex("dbo.Orders", "DelivererId");
            AddForeignKey("dbo.Orders", "DelivererId", "dbo.Deliverers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DelivererId", "dbo.Deliverers");
            DropIndex("dbo.Orders", new[] { "DelivererId" });
            AlterColumn("dbo.Orders", "DelivererId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "DelivererId");
            AddForeignKey("dbo.Orders", "DelivererId", "dbo.Deliverers", "Id", cascadeDelete: true);
        }
    }
}
