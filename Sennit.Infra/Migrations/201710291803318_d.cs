namespace Sennit.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Coupon", new[] { "customer_Id" });
            CreateIndex("dbo.Coupon", "Customer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Coupon", new[] { "Customer_Id" });
            CreateIndex("dbo.Coupon", "customer_Id");
        }
    }
}
