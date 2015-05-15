namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotations", "CustomerReference", c => c.String(maxLength: 128));
            AddColumn("dbo.Quotations", "Comments", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "Comments");
            DropColumn("dbo.Quotations", "CustomerReference");
        }
    }
}
