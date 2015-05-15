namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update004 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "UnitOfMeasure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "UnitOfMeasure", c => c.String());
        }
    }
}
