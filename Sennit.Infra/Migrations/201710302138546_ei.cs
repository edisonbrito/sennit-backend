namespace Sennit.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ei : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role", c => c.String());
            DropColumn("dbo.User", "IsAdmin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "IsAdmin", c => c.Boolean(nullable: false));
            DropColumn("dbo.User", "Role");
        }
    }
}
