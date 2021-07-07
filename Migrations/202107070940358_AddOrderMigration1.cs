namespace Manager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "DateOut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderComposition", c => c.String());
            AddColumn("dbo.Orders", "DeliveryMethod", c => c.String());
            AddColumn("dbo.Orders", "CommunicationMethod", c => c.String());
            AddColumn("dbo.Orders", "OrderAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "DeliveryAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Prepayment", c => c.Double(nullable: false));
            AddColumn("dbo.Orders", "Celebration", c => c.String());
            AddColumn("dbo.Orders", "DateIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "DateIn");
            DropColumn("dbo.Orders", "Celebration");
            DropColumn("dbo.Orders", "Prepayment");
            DropColumn("dbo.Orders", "DeliveryAmount");
            DropColumn("dbo.Orders", "OrderAmount");
            DropColumn("dbo.Orders", "CommunicationMethod");
            DropColumn("dbo.Orders", "DeliveryMethod");
            DropColumn("dbo.Orders", "OrderComposition");
            DropColumn("dbo.Orders", "DateOut");
            DropColumn("dbo.Orders", "Status");
        }
    }
}
