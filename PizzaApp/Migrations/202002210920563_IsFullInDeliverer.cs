namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsFullInDeliverer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Deliverers", "IsFull", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Deliverers", "IsFull");
        }
    }
}
