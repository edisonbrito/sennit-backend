namespace Sennit.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer");
            DropIndex("dbo.Coupon", new[] { "Customer_Id" });
            AddColumn("dbo.Coupon", "IdCustomer", c => c.Int());
            DropColumn("dbo.Coupon", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coupon", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Coupon", "IdCustomer");
            CreateIndex("dbo.Coupon", "Customer_Id");
            AddForeignKey("dbo.Coupon", "Customer_Id", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
