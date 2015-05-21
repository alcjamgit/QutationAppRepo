namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update007 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotations", "Uom", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "Uom");
        }
    }
}
