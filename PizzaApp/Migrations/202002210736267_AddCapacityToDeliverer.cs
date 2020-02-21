namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCapacityToDeliverer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliverers", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deliverers", "Capacity");
        }
    }
}
