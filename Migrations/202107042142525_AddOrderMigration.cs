namespace Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderMigration : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "OrderComposition");
            DropColumn("dbo.Orders", "DeliveryMethod");
            DropColumn("dbo.Orders", "OrderAmount");
            DropColumn("dbo.Orders", "DeliveryAmount");
            DropColumn("dbo.Orders", "Prepayment");
            DropColumn("dbo.Orders", "Celebration");
            DropColumn("dbo.Orders", "DateIn");
            DropColumn("dbo.Orders", "CustomerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "DateIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "Celebration", c => c.String());
            AddColumn("dbo.Orders", "Prepayment", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "OrderAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "DeliveryMethod", c => c.String());
            AddColumn("dbo.Orders", "OrderComposition", c => c.String());
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
        }
    }
}
