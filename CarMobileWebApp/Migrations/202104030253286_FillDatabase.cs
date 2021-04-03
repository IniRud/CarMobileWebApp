namespace CarMobileWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FillDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.CarModels(Model, Production) VALUES('BMW', '2020') ");
            Sql("INSERT INTO dbo.CarModels(Model, Production) VALUES('Audi','2020') ");
            Sql("INSERT INTO dbo.CarModels(Model, Production) VALUES('Ferrari','2010') ");
            Sql("INSERT INTO dbo.CarModels(Model, Production) VALUES('Porsche','2020') ");
        }
        
        public override void Down()
        {
        }
    }
}
