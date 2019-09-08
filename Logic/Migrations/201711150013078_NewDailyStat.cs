namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDailyStat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        SellingPrice = c.Double(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                        Product_Code = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Code)
                .Index(t => t.Product_Code);
            
            DropColumn("dbo.Products", "SellingPrice");
            DropColumn("dbo.Products", "PurchasePrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "PurchasePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "SellingPrice", c => c.Double(nullable: false));
            DropForeignKey("dbo.ProductPrices", "Product_Code", "dbo.Products");
            DropIndex("dbo.ProductPrices", new[] { "Product_Code" });
            DropTable("dbo.ProductPrices");
        }
    }
}
