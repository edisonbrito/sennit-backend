namespace Sennit.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class di : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Coupon", new[] { "Customer_Id" });
            AlterColumn("dbo.Coupon", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Coupon", "Customer_Id");
            AddForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Coupon", new[] { "Customer_Id" });
            AlterColumn("dbo.Coupon", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Coupon", "Customer_Id");
            AddForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer", "Id");
        }
    }
}
