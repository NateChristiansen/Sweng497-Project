namespace ErieGarbageOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Unpaid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Unpaid");
        }
    }
}
