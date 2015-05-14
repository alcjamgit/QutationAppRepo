namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotations", "Status", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "Status");
        }
    }
}
