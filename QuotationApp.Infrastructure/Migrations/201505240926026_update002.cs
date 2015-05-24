namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Quotations", "Product_Id", "dbo.Products");
            DropIndex("dbo.Quotations", new[] { "Product_Id" });
            AddColumn("dbo.Quotations", "Product_Description", c => c.String(maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quotations", "Product_Description");
            CreateIndex("dbo.Quotations", "Product_Id");
            AddForeignKey("dbo.Quotations", "Product_Id", "dbo.Products", "Id");
        }
    }
}
