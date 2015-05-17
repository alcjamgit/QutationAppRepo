namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Upadate006 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuotationLineItems", "Quotation_Id", "dbo.Quotations");
            DropIndex("dbo.QuotationLineItems", new[] { "Quotation_Id" });
            AddColumn("dbo.Quotations", "Product_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Quotations", "MinOrderQty", c => c.Int(nullable: false));
            AddColumn("dbo.Quotations", "UnitOfMeasure", c => c.String());
            AddColumn("dbo.Quotations", "QuotedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Quotations", "Product_Id");
            AddForeignKey("dbo.Quotations", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.QuotationLineItems", "Quotation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.QuotationLineItems", "Quotation_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Quotations", "Product_Id", "dbo.Products");
            DropIndex("dbo.Quotations", new[] { "Product_Id" });
            DropColumn("dbo.Quotations", "QuotedPrice");
            DropColumn("dbo.Quotations", "UnitOfMeasure");
            DropColumn("dbo.Quotations", "MinOrderQty");
            DropColumn("dbo.Quotations", "Product_Id");
            CreateIndex("dbo.QuotationLineItems", "Quotation_Id");
            AddForeignKey("dbo.QuotationLineItems", "Quotation_Id", "dbo.Quotations", "Id");
        }
    }
}
