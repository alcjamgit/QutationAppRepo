namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update009 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Quotations", "UnitOfMeasure");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Quotations", "UnitOfMeasure", c => c.String());
        }
    }
}
