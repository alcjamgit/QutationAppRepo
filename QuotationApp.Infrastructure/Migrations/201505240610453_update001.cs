namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update001 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quotations", "AttachmentFileName", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "AttachmentFileName");
        }
    }
}
