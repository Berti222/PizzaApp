namespace PizzaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDataInPizzaTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Pizzas( Name, Price) VALUES ('Margarita', 1000)");
            Sql("INSERT INTO Pizzas( Name, Price) VALUES ('Carbonara', 1500)");
            Sql("INSERT INTO Pizzas( Name, Price) VALUES ('Hawaii', 1300)");
            Sql("INSERT INTO Pizzas( Name, Price) VALUES ('Funghi', 1300)");
        }
        
        public override void Down()
        {
        }
    }
}
