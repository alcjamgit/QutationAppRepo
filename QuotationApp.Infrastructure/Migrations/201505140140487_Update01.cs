namespace QuotationApp.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.QuotationLineItems", "SortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Quotations", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.QuotationLineItems", "Id");
            CreateIndex("dbo.Quotations", "Id");
            CreateIndex("dbo.Quotations", "Customer_Id");
            AddForeignKey("dbo.Quotations", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quotations", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Quotations", new[] { "Customer_Id" });
            DropIndex("dbo.Quotations", new[] { "Id" });
            DropIndex("dbo.QuotationLineItems", new[] { "Id" });
            DropColumn("dbo.Quotations", "Customer_Id");
            DropColumn("dbo.QuotationLineItems", "SortOrder");
            DropTable("dbo.Customers");
        }
    }
}
