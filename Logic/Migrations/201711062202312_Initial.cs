namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moneys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        VMachine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VMachines", t => t.VMachine_Id)
                .Index(t => t.VMachine_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 4),
                        Name = c.String(),
                        SellingPrice = c.Double(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.VMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilledVMs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        FVMachine_Id = c.Int(),
                        Product_Code = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VMachines", t => t.FVMachine_Id)
                .ForeignKey("dbo.Products", t => t.Product_Code)
                .Index(t => t.FVMachine_Id)
                .Index(t => t.Product_Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilledVMs", "Product_Code", "dbo.Products");
            DropForeignKey("dbo.FilledVMs", "FVMachine_Id", "dbo.VMachines");
            DropForeignKey("dbo.Moneys", "VMachine_Id", "dbo.VMachines");
            DropIndex("dbo.FilledVMs", new[] { "Product_Code" });
            DropIndex("dbo.FilledVMs", new[] { "FVMachine_Id" });
            DropIndex("dbo.Moneys", new[] { "VMachine_Id" });
            DropTable("dbo.FilledVMs");
            DropTable("dbo.VMachines");
            DropTable("dbo.Products");
            DropTable("dbo.Moneys");
        }
    }
}
