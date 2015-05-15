namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitOfMeasure", c => c.String());
            AddColumn("dbo.Products", "Discontinued", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Discontinued");
            DropColumn("dbo.Products", "UnitOfMeasure");
        }
    }
}
