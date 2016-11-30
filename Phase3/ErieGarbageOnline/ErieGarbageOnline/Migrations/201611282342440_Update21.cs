using System.Data.Entity.Migrations;

namespace ErieGarbageOnline.Migrations
{
    public partial class Update21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "Unpaid", c => c.Boolean(false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "Unpaid");
        }
    }
}
