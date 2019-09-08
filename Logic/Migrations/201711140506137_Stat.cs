namespace Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Stat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DailyStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Code = c.String(maxLength: 4),
                        VMachine_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Code)
                .ForeignKey("dbo.VMachines", t => t.VMachine_Id)
                .Index(t => t.Product_Code)
                .Index(t => t.VMachine_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DailyStatistics", "VMachine_Id", "dbo.VMachines");
            DropForeignKey("dbo.DailyStatistics", "Product_Code", "dbo.Products");
            DropIndex("dbo.DailyStatistics", new[] { "VMachine_Id" });
            DropIndex("dbo.DailyStatistics", new[] { "Product_Code" });
            DropTable("dbo.DailyStatistics");
        }
    }
}
