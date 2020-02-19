namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeliverers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deliverers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Vehicle = c.String(),
                        IsOnWay = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Deliverers");
        }
    }
}
