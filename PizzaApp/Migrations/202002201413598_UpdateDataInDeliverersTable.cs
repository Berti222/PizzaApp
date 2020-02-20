namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataInDeliverersTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Deliverers (Name, Vehicle, IsOnWay) VALUES ('Kiss Róbert', 'Autó', 'False')");
            Sql("INSERT INTO Deliverers (Name, Vehicle, IsOnWay) VALUES ('Nagy Károly', 'Motorkerékpár', 'False')");
            Sql("INSERT INTO Deliverers (Name, Vehicle, IsOnWay) VALUES ('Kovács Zsolt', 'Autó', 'False')");
        }
        
        public override void Down()
        {
        }
    }
}
