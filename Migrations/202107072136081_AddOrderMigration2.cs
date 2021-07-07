namespace Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderMigration2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CakePrice", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "TotalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalPrice");
            DropColumn("dbo.Orders", "CakePrice");
        }
    }
}
