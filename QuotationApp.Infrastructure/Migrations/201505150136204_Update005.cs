namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitOfMeasure", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitOfMeasure");
        }
    }
}
