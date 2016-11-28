namespace ErieGarbageOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Bills", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Messages", "MessageType", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "MessageBody", c => c.String());
            AddColumn("dbo.Messages", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "Date");
            DropColumn("dbo.Messages", "MessageBody");
            DropColumn("dbo.Messages", "CustomerId");
            DropColumn("dbo.Messages", "MessageType");
            DropColumn("dbo.Bills", "Amount");
            DropColumn("dbo.Bills", "Date");
            DropColumn("dbo.Bills", "CustomerId");
        }
    }
}
