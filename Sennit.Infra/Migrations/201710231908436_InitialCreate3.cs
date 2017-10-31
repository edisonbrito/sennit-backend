namespace Sennit.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupon", "customer_Id", c => c.Int());
            CreateIndex("dbo.Coupon", "customer_Id");
            AddForeignKey("dbo.Coupon", "customer_Id", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coupon", "customer_Id", "dbo.Customer");
            DropIndex("dbo.Coupon", new[] { "customer_Id" });
            DropColumn("dbo.Coupon", "customer_Id");
        }
    }
}
