namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PutDataInDeliverersTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Deliverers SET Capacity = 10 WHERE Name = 'Kiss Róbert' ");
            Sql("UPDATE Deliverers SET Capacity = 5 WHERE Name = 'Nagy Károly' ");
            Sql("UPDATE Deliverers SET Capacity = 10 WHERE Name = 'Kovács Zsolt' ");
        }
        
        public override void Down()
        {
        }
    }
}
